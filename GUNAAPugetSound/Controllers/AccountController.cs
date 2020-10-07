using System;
using System.Collections.Generic;
using AutoMapper;
using Contracts;
using Entities.DTOs.Accounts;
using Entities.Models;
using GUNAAPugetSound.Entities.Enums;
using GUNAAPugetSound.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BC = BCrypt.Net.BCrypt;

namespace GUNAAPugetSound.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : BaseController
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;

        public AccountController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper, AppSettings appSettings, IEmailService emailService)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _appSettings = appSettings;
            _emailService = emailService;
        }
        [HttpPost("authenticate")]
        public ActionResult<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var account = _repository.Account.GetAccountByEmail(model.Email);

            if (account == null || !account.IsVerified || !BC.Verify(model.Password, account.PasswordHash))
                throw new AppException("Email or password is incorrect");
            _repository.Account.Authenticate(IpAddress(), _appSettings.Secret, ref account, out string jwtToken, out RefreshToken refreshToken);
            var response = _mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            response.RefreshToken = refreshToken.Token;
            SetTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public ActionResult<AuthenticateResponse> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var account = _repository.Account.RefreshToken(refreshToken, IpAddress(), _appSettings.Secret, out string jwtToken, out RefreshToken newRefreshToken);
            var response = _mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            response.RefreshToken = newRefreshToken.Token;
            SetTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [Helpers.Authorize]
        [HttpPost("revoke-token")]
        public IActionResult RevokeToken(RevokeTokenRequest model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            // users can revoke their own tokens and admins can revoke any tokens
            if (!Account.OwnsToken(token) && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            _repository.Account.RevokeToken(token, IpAddress());
            return Ok(new { message = "Token revoked" });
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            // map model to new account object
            var registered =  _repository.Account.AccountExists(model.Email);
            if (registered)
            {
                _repository.Account.SendAlreadyRegisteredEmail(model.Email, Request.Headers["origin"], _emailService);
                return Ok(new
                {
                    message =
                        "You have already registered your account. Please check your email again for verification instructions"
                });
            }

            var account = _mapper.Map<Account>(model); 
            // hash password
            account.PasswordHash = BC.HashPassword(model.Password);

            _repository.Account.Register(model, Request.Headers["origin"], account, _emailService);
            return Ok(new { message = "Registration successful, please check your email for verification instructions" });
        }

        [HttpPost("verify-email")]
        public IActionResult VerifyEmail(VerifyEmailRequest model)
        {
            var account = _repository.Account.VerifyEmail(model.Token);
            if (account == null) throw new AppException("Verification failed");
            _repository.Account.SaveVerificationToken(model.Token, ref account);
            return Ok(new { message = "Verification successful, you can now login" });
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword(ForgotPasswordRequest model)
        {
            _repository.Account.ForgotPassword(model, Request.Headers["origin"], _emailService);
            return Ok(new { message = "Please check your email for password reset instructions" });
        }

        [HttpPost("validate-reset-token")]
        public IActionResult ValidateResetToken(ValidateResetTokenRequest model)
        {
            var account = _repository.Account.ValidateResetToken(model.Token);
            if (account == null)
                throw new AppException("Invalid token");
            return Ok(new { message = "Token is valid" });
        }

        [HttpPost("reset-password")]
        public IActionResult ResetPassword(ResetPasswordRequest model)
        {
            var account = _repository.Account.ValidateResetToken(model.Token);
            if (account == null)
                throw new AppException("Invalid token");

            _repository.Account.ResetPassword(model, account);
            return Ok(new { message = "Password reset successful, you can now login" });
        }

        [Helpers.Authorize(Role.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<AccountResponse>> GetAll()
        {
            var accounts = _mapper.Map<IList<AccountResponse>>(_repository.Account.GetAll());
            return Ok(accounts);
        }

        [Helpers.Authorize]
        [HttpGet("{id:int}")]
        public ActionResult<AccountResponse> GetById(int id)
        {
            // users can get their own account and admins can get any account
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _repository.Account.GetById(id);
            return Ok(account);
        }

        [Helpers.Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<AccountResponse> Create(CreateRequest model)
        {
            // validate
            if (_repository.Account.AccountExists(model.Email))
                throw new AppException($"Email '{model.Email}' is already registered");

            // map model to new account object
            var account = _mapper.Map<Account>(model);

            // hash password
            account.PasswordHash = BC.HashPassword(model.Password);

            _repository.Account.Create(account);
            var accountResponse = _mapper.Map<AccountResponse>(account);
            return Ok(accountResponse);
        }

        [Helpers.Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<AccountResponse> Update(int id, UpdateRequest model)
        {
            // users can update their own account and admins can update any account
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            // only admins can update role
            if (Account.Role != Role.Admin)
                model.Role = null;
            var account = _repository.Account.GetById(id);
            // validate
            if (account.Email != model.Email && _repository.Account.AccountExists(model.Email))
                throw new AppException($"Email '{model.Email}' is already taken");
            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                account.PasswordHash = BC.HashPassword(model.Password);

            // copy model to account and save
            _mapper.Map(model, account);

            _repository.Account.Update(account);
            var accountResponse =_mapper.Map<AccountResponse>(account);
            return Ok(accountResponse);
        }

        [Helpers.Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            // users can delete their own account and admins can delete any account
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _repository.Account.GetById(id);
            _repository.Account.Delete(account);
            return Ok(new { message = "Account deleted successfully" });
        }

        // helper methods

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

    }
}