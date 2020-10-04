using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs.Accounts;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Contracts
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);
        void Register(RegisterRequest model, string origin);
        void VerifyEmail(string token);
        void ForgotPassword(ForgotPasswordRequest account, string origin);
        void ValidateResetToken(ValidateResetTokenRequest account);
        void ResetPassword(ResetPasswordRequest account);
        IEnumerable<Account> GetAll();
        AccountResponse GetById(int id);
        AccountResponse CreateAccount(CreateRequest account);
        AccountResponse UpdateAccount(UpdateRequest account);
        void DeleteAccount(int id);
    }
}
