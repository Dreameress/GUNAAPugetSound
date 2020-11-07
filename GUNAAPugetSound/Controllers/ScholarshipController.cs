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
                html: $@"
        <div style='background: #fff; flex: box; color: #000; padding: 50px; border-radius: 20px; border-color: #000; border: 1px solid; font-family: georgia; max-width: 700px;'>
                <h1 style='text-align: center;'>Scholarship Form Submission</h1>
                <br />
                <h2 style='text-align: center;'> Scholarship Form for { model.NameFirst + ' ' + model.NameLast}</h2>
                <br/>

                <div style=' display: grid; grid-template-columns: repeat(1, 1fr); '>
                    <div>
                        <h4 style ='font-weight: 900;'>Personal Information:</h4>
                    </div>
                    <div id='form-row' style ='position: relative;'>
                        <label style='font-weight: 600; font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px; width: 75%;'>Applicants Name</label>
                        <input type ='text' style ='margin-bottom: 27px; width: 100%;' readonly value='{model.NameFirst + " " + model.NameLast}' />
                    </div>
                    <div id='form-row' style ='position: relative;'>
                        <label style='font-weight: 600; font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px; width: 75%;'>Permanent Address</label>
                        <input type ='text' style ='margin-bottom: 27px; width: 100%;' readonly value='{model.Address}' />
                    </div>
                    <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>City</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.City}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>State</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.State}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Zip Code</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.ZipCode}' />
                        </div>
                    </div>
                    <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 50%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Phone</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.Phone}' />
                        </div>
                        <div style='width: 50%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Email</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.Email}' />
                        </div>
                    </div>
                    <div id='form-row' style ='position: relative;'>
                        <label style='font-weight: 600; font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px; width: 100;'>Current Address</label>
                        <input type ='text' style ='margin-bottom: 27px; width: 100%;' readonly value='{model.CurrentAddress}' />
                    </div>
                    <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>City</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.CurrentCity}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>State</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.CurrentState}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Zip Code</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.CurrentZipCode}' />
                        </div>
                    </div>
                    <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 50%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Phone</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.CurrentPhone}' />
                        </div>
                        <div style='width: 50%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Email</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.CurrentEmail}' />
                        </div>
                    </div>
                    <div id='form-row' style ='position: relative;'>
                        <label style='font-weight: 600; font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px; width: 100;'>Last School Attended Name</label>
                        <input type ='text' style ='margin-bottom: 27px; width: 100%;' readonly value='{model.LastSchool}' />
                    </div>
                    <div id='form-row' style ='position: relative;'>
                        <label style='font-weight: 600; font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px; width: 100;'>Last School Attended Address</label>
                        <input type ='text' style ='margin-bottom: 27px; width: 100%;' readonly value='{model.LastSchoolAddress}' />
                    </div>
                    <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>City</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LastSchoolCity}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>State</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LastSchoolState}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Zip Code</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LastSchoolZipCode}' />
                        </div>
                    </div>
                    <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 50%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Phone</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LastSchoolPhone}' />
                        </div>
                        <div style='width: 50%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Email</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LastSchoolEmail}' />
                        </div>
                    </div>
                    <div>
                        <h4 style ='font-weight: 900;'>College Plans:</h4>
                    </div>
                    <div id='form-row' style ='position: relative;'>
                        <label style='font-weight: 600; font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px; width: 75%;'>What is your proposed field of study?</label>
                        <input type ='text' style ='margin-bottom: 27px; width: 100%;' readonly value='{model.FieldOfStudy}' />
                    </div>
                    <div id='form-row' style ='position: relative;'>
                        <label style='font-weight: 600; font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px; width: 75%;'>How did you hear abut Grambling State University?</label>
                        <textarea  style ='margin-bottom: 27px; width: 100%;'  readonly>{model.Source}</textarea>
                    </div>
                    <div>
                        <h4 style ='font-weight: 900;'>Name and Address of Family Members that Graduated from or attended Grambling University:</h4>
                    </div>
                    <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>City</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyNameFirst1}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>State</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyNameLast1}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Zip Code</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyRelation1}' />
                        </div>
                    </div> 
                    <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>City</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyCity1}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>State</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyState1}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Zip Code</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyZipCode1}' />
                        </div>
                    </div> 
                   <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>City</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyNameFirst2}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>State</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyNameLast2}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Zip Code</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyRelation2}' />
                        </div>
                    </div> 
                    <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>City</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyCity2}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>State</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyState2}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Zip Code</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyZipCode2}' />
                        </div>
                    </div> 
                    <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>City</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyNameFirst3}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>State</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyNameLast3}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Zip Code</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyRelation3}' />
                        </div>
                    </div> 
                    <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>City</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyCity3}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>State</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyState3}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Zip Code</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyZipCode3}' />
                        </div>
                    </div>
                    <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>City</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyNameFirst4}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>State</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyNameLast4}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Zip Code</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyRelation4}' />
                        </div>
                    </div> 
                    <div id='form-group' style='display: -webkit-flex;margin:0-8px;'>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>City</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyCity4}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>State</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyState4}' />
                        </div>
                        <div style='width: 33%; padding: 0 8px;'>
                            <label style='font-weight: 600;font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px;'>Zip Code</label>
                            <input type='text' style='margin-bottom: 27px; width: 100%;' readonly value='{model.LegacyZipCode4}' />
                        </div>
                    </div> 
                    <div>
                        <h4 style ='font-weight: 900;'>Achievements:</h4>
                    </div>
                    <div id='form-row' style ='position: relative;'>
                        <label style='font-weight: 600; font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px; width: 75%;'>Extra-Curricular Activities</label>
                          <textarea  style ='margin-bottom: 27px; width: 100%;'  readonly>{model.ExtraCurricular}</textarea>
                    </div>
                    <div id='form-row' style ='position: relative;'>
                        <label style='font-weight: 600; font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px; width: 75%;'>Positions of Leadership</label>
                         <textarea  style ='margin-bottom: 27px; width: 100%;'  readonly>{model.Leadership}</textarea>
                    </div>
                    <div id='form-row' style ='position: relative;'>
                        <label style='font-weight: 600; font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px; width: 75%;'>Academic Honors</label>
                        <textarea  style ='margin-bottom: 27px; width: 100%;'  readonly>{model.AcademicHonors}</textarea>
                    </div>
                    <div id='form-row' style ='position: relative;'>
                        <label style='font-weight: 600; font-size: 15px; color: #DEA638; display: block; margin-bottom: 8px; width: 75%;'>School/Community/Church/Service Activities</label>
                       <textarea  style ='margin-bottom: 27px; width: 100%;'  readonly>{model.Activities}</textarea>
                    </div>
               
                </div>
               
          </div>"
            );

            return Ok(new { message = "Scholarship Form successfully submitted" });
        }

    }
}
