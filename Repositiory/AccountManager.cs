using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Contracts;
using Entities.DTOs.Accounts;
using Entities.Models;
using GUNAAPugetSound.Entities;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using GUNAAPugetSound.Entities.Enums;
using Microsoft.IdentityModel.Tokens;
using BC = BCrypt.Net.BCrypt;

namespace Repository
{
    class AccountManager : RepositoryBase<Account>, IAccountManager
    {
        
        public AccountManager(GUNAADbContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public void Authenticate(string ipAddress, string secret, ref Account account, out string jwtToken, out RefreshToken refreshToken)
        {
            // authentication successful so generate jwt and refresh tokens
            jwtToken = generateJwtToken(account, secret);
            refreshToken = generateRefreshToken(ipAddress);

            // save refresh token
            account.RefreshTokens?.Add(refreshToken);
            RepositoryContext.Update(account);
            RepositoryContext.SaveChanges();
        }

        public Account RefreshToken(string token, string ipAddress, string secret, out string jwtToken, out RefreshToken newRefreshToken)
        {
            var (refreshToken, account) = getRefreshToken(token);

            // replace old refresh token with a new one and save
            newRefreshToken = generateRefreshToken(ipAddress);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            account.RefreshTokens.Add(newRefreshToken);
            RepositoryContext.Update(account);
            RepositoryContext.SaveChanges();

            // generate new jwt
            jwtToken = generateJwtToken(account, secret);
            return account;
        }

        public void RevokeToken(string token, string ipAddress)
        {
            var (refreshToken, account) = getRefreshToken(token);

            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            RepositoryContext.Update(account);
            RepositoryContext.SaveChanges();
        }

        public bool AccountExists(string email)
        {
            // validate
            return RepositoryContext.Accounts.Any(x => x.Email == email);
        }
        public bool SendAlreadyRegisteredEmail(string email, string origin, IEmailService emailService)
        {
            // send already registered error in email to prevent account enumeration
            sendAlreadyRegisteredEmail(email, origin, emailService);
            return true;
        }

        public void Register(RegisterRequest model, string origin, Account account, IEmailService emailService)
        {
            // first registered account is an admin
            var isFirstAccount = !RepositoryContext.Accounts.Any();
            account.Role = isFirstAccount ? Role.Admin : Role.Member;
            account.Created = DateTime.UtcNow;
            account.VerificationToken = randomTokenString();

            // save account
            RepositoryContext.Accounts.Add(account);
            RepositoryContext.SaveChanges();

            // send email
            sendVerificationEmail(account, origin, emailService);
        }

        public Account VerifyEmail(string token)
        {
            return RepositoryContext.Accounts.SingleOrDefault(x => x.VerificationToken == token);
        }

        public void SaveVerificationToken(string token, ref Account account)
        {
            account.Verified = DateTime.UtcNow;
            account.VerificationToken = null;

            RepositoryContext.Accounts.Update(account);
            RepositoryContext.SaveChanges();
        }

        public void ForgotPassword(ForgotPasswordRequest model, string origin, IEmailService emailService)
        {
            var account = RepositoryContext.Accounts.SingleOrDefault(x => x.Email == model.Email);

            // always return ok response to prevent email enumeration
            if (account == null) return;

            // create reset token that expires after 1 day
            account.ResetToken = randomTokenString();
            account.ResetTokenExpires = DateTime.UtcNow.AddDays(24);

            RepositoryContext.Accounts.Update(account);
            RepositoryContext.SaveChanges();

            // send email
            sendPasswordResetEmail(account, origin, emailService);
        }

        public Account ValidateResetToken(string token)
        {
            return RepositoryContext.Accounts.SingleOrDefault(x =>
                x.ResetToken == token &&
                x.ResetTokenExpires > DateTime.UtcNow);
        }

        public void ResetPassword(ResetPasswordRequest model, Account account)
        {
            // update password and remove reset token
            account.PasswordHash = BC.HashPassword(model.Password);
            account.PasswordReset = DateTime.UtcNow;
            account.ResetToken = null;
            account.ResetTokenExpires = null;

            RepositoryContext.Accounts.Update(account);
            RepositoryContext.SaveChanges();
        }

        public IEnumerable<Account> GetAll()
        {
            return RepositoryContext.Accounts;
        }

        public Account GetAccountByEmail(string email)
        {
            return RepositoryContext.Accounts.SingleOrDefault(x => x.Email == email);
        }

        public Account GetById(int id)
        {
            return getAccount(id);
        }

        public Account Create(ref Account account)
        {
            // save account

            account.Created = DateTime.UtcNow;
            account.Verified = DateTime.UtcNow;
            RepositoryContext.Accounts.Add(account);
            RepositoryContext.SaveChanges();
            return account;
        }

        public Account Update(ref Account account)
        {
            account.Updated = DateTime.UtcNow;
            RepositoryContext.Accounts.Update(account);
            RepositoryContext.SaveChanges();

            return account;
        }

        public void Delete(Account account)
        {
            RepositoryContext.Accounts.Remove(account);
            RepositoryContext.SaveChanges();
        }

        // helper methods

        private Account getAccount(int id)
        {
            var account = RepositoryContext.Accounts.Find(id);
            if (account == null) throw new KeyNotFoundException("Account not found");
            return account;
        }

        private (RefreshToken, Account) getRefreshToken(string token)
        {
            var account = RepositoryContext.Accounts.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));
            if (account == null) throw new Exception("Invalid token");
            var refreshToken = account.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive) throw new Exception("Invalid token");
            return (refreshToken, account);
        }


        private string generateJwtToken(Account account, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private RefreshToken generateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = randomTokenString(),
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }

        private string randomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }

        private void sendVerificationEmail(Account account, string origin, IEmailService emailService)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var verifyUrl = $"{origin}/api/account/verify-email?token={account.VerificationToken}";
                message = $@"<p>Please click the below link to verify your email address:</p>
                             <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
            }
            else
            {
                message = $@"<p>Please use the below token to verify your email address with the <code>/accounts/verify-email</code> api route:</p>
                             <p><code>{account.VerificationToken}</code></p>";
            }

            emailService.Send(
                to: account.Email,
                subject: "Sign-up Verification API - Verify Email",
                html: $@"<h4>Verify Email</h4>
                         <p>Thanks for registering!</p>
                         {message}"
            );
        }

        private void sendAlreadyRegisteredEmail(string email, string origin, IEmailService emailService)
        {
            var message = !string.IsNullOrEmpty(origin) ? 
                $@"<p>If you don't know your password please visit the <a href=""{origin}/api/account/forgot-password"">forgot password</a> page.</p>" 
                : "<p>If you don't know your password you can reset it via the <code>/accounts/forgot-password</code> api route.</p>";

            emailService.Send(
                to: email,
                subject: "Sign-up Verification API - Email Already Registered",
                html: $@"<h4>Email Already Registered</h4>
                         <p>Your email <strong>{email}</strong> is already registered.</p>
                         {message}"
            );
        }

        private void sendPasswordResetEmail(Account account, string origin, IEmailService emailService)
        {
            string message;
            if (!string.IsNullOrEmpty(origin))
            {
                var resetUrl = $"{origin}/api/account/reset-password?token={account.ResetToken}";
                message = $@"<p>Please click the below link to reset your password, the link will be valid for 1 day:</p>
                             <p><a href=""{resetUrl}"">{resetUrl}</a></p>";
            }
            else
            {
                message = $@"<p>Please use the below token to reset your password with the <code>/api/accounts/reset-password</code> api route:</p>
                             <p><code>{account.ResetToken}</code></p>";
            }

            emailService.Send(
                to: account.Email,
                subject: "Sign-up Verification API - Reset Password",
                html: $@"<h4>Reset Password Email</h4>
                         {message}"
            );
        }
    }
}
