using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs.Accounts;
using Entities.Models;

namespace Contracts
{
    public interface IAccountManager : IRepositoryBase<Account>
    {
        void Authenticate(string ipAddress, string secret, ref Account accounts, out string jwtToken, out RefreshToken refreshToken);
        Account RefreshToken(string token, string ipAddress, string secret, out string jwtToken,
            out RefreshToken refreshToken);
        void RevokeToken(string token, string ipAddress);
        bool AccountExists(string email);
        bool SendAlreadyRegisteredEmail(string email, string origin, IEmailService emailService);
        void Register(RegisterRequest model, string origin, Account account, IEmailService emailService);
        Account VerifyEmail(string token);
        void SaveVerificationToken(string token, ref Account account);
        void ForgotPassword(ForgotPasswordRequest model, string origin, IEmailService emailService);
        Account ValidateResetToken(string token);
        void ResetPassword(ResetPasswordRequest model, Account account);
        IEnumerable<Account> GetAll();
        Account GetAccountByEmail(string email);
        Account GetById(int id);
        Account Create(ref Account account);
        Account Update(ref Account account);
        void Delete(Account account);
    }
}
