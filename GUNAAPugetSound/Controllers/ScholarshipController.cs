using System.IO.Compression;
using System.Text;
using AutoMapper;
using Contracts;
using Entities.DTOs.Scholarship;
using GUNAAPugetSound.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost("submit")]
        public IActionResult SubmitScholarshipForm(ScholarshipFormSubmissionRequest model)
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
            var sb = new StringBuilder();
      
            _emailService.SendScholarship(
                subject: "GUNAA Puget Sound Scholarship Form Submission",
                html: $@"<h4>Scholarship Form</h4>
                         <br />
                         <p>Scholarship Form for {model.NameFirst + " " + model.NameLast}</p>]
                         <p>Applicant's Name: {model.NameFirst + model.NameLast}</p>
                         <p>Permanent Address: {model.Address}</p>
                         <p>City: {model.City} | State: {model.State} | Zip: {model.ZipCode}
                         <p>Phone: {model.Phone}</p>
                         <p>Last School Attended: {model.LastSchool} | School Phone #: {model.SchoolPhone}</p>
                         <p>School Address: {model.LastSchoolAddress}</p>
                         <p>College Plans: {model.CompleteTime}</p>
                         <p></p>
                         {message}"
            );

            return Ok(new { message = "Scholarship Form successfully submitted" });
        }

    }
}
