using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities.DTOs.Accounts;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Repository
{
    class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(GUNAARepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public void RevokeToken(string token, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public void Register(RegisterRequest model, string origin)
        {
            throw new NotImplementedException();
        }

        public void VerifyEmail(string token)
        {
            throw new NotImplementedException();
        }

        public void ForgotPassword(ForgotPasswordRequest account, string origin)
        {
            throw new NotImplementedException();
        }

        public void ValidateResetToken(ValidateResetTokenRequest account)
        {
            throw new NotImplementedException();
        }

        public void ResetPassword(ResetPasswordRequest account)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public AccountResponse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public AccountResponse CreateAccount(CreateRequest account)
        {
            throw new NotImplementedException();
        }

        public AccountResponse UpdateAccount(UpdateRequest account)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }
    }
}
