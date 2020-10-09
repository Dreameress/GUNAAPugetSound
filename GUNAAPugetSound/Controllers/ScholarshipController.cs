using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DTOs.Accounts;
using GUNAAPugetSound.Helpers;
using GUNAAPugetSound.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GUNAAPugetSound.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScholarshipController :BaseController
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly IEmailService _emailService;

        public ScholarshipController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper, IOptions<AppSettings> appSettings, IEmailService emailService)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _emailService = emailService;
        }

        [HttpPost("authenticate")]
        public IActionResult SubmitScholarshipFrom(ScholarshipFromSubmissionRequest model)
        {
            //Create HTML Form with model data
            string message;
            message = "test";
            //if (!string.IsNullOrEmpty(origin))
            //{
            //    var verifyUrl = $"{origin}/api/account/verify-email?token={account.VerificationToken}";
            //    message = $@"<p>Please click the below link to verify your email address:</p>
            //                 <p><a href=""{verifyUrl}"">{verifyUrl}</a></p>";
            //}
            //else
            //{
            //    message = $@"<p>Please use the below token to verify your email address with the <code>/accounts/verify-email</code> api route:</p>
            //                 <p><code>{account.VerificationToken}</code></p>";
            //}

            _emailService.SendScholarship(
                subject: "GUNAA Puget Sound Scholarship Form Submission",
                html: $@"<h4>Scholarship Form</h4>
                         <br />
                         <p>Thanks for registering!</p>
                         {message}"
            );

            return Ok(new { message = "Scholarship Form successfully submitted" });
        }

    }
}
