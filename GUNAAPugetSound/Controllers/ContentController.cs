
using AutoMapper;
using Contracts;
using Entities.DTOs.Content;
using Entities.Models;
using GUNAAPugetSound.Entities.Enums;
using GUNAAPugetSound.Helpers;
using GUNAAPugetSound.Services;
using Microsoft.AspNetCore.Mvc;

namespace GUNAAPugetSound.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : BaseController
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ContentController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper, AppSettings appSettings, IEmailService emailService)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _appSettings = appSettings;
        }

        #region Get Content
        [HttpGet]
        public ActionResult<ContentResponse> GetContent()
        {
            ContentResponse contentResponse = new ContentResponse
            {
                Content = _repository.Content.GetContent(),
                Officers = _repository.Officer.GetActiveOfficers(),
                CommitteeMembers = _repository.CommitteeMember.GetActiveCommitteeMembers(),
                Events = _repository.Event.GetAllEvents(),
                Albums = _repository.Album.GetAllAlbums()
            };
            return Ok(contentResponse);
        }
        #endregion



        #region Update Content

        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> UpdateHomeContent(UpdateHomeContentRequest model)
        {
            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.HomeSubHeader))
            {
                content.HomeSubHeader = model.HomeSubHeader;
            }
            if (!string.IsNullOrEmpty(model.HomeLine1))
            {
                content.HomeLine1 = model.HomeLine1;
            }

            if (!string.IsNullOrEmpty(model.HomeLine2))
            {
                content.HomeLine2 = model.HomeLine2;
            }

            if (!string.IsNullOrEmpty(model.HomeLine3))
            {
                content.HomeLine3 = model.HomeLine3;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            return Ok(content);
        }

        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> UpdateOfficerContent(UpdateOfficerContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.OfficersSubHeader))
            {
                content.OfficersSubHeader = model.OfficersSubHeader;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            return Ok(content);
        }


        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> UpdateCommitteeContent(UpdateCommitteeContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.CommitteesSubHeader))
            {
                content.CommitteesSubHeader = model.CommitteesSubHeader;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            return Ok(content);
        }


        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> UpdateMembershipContent(UpdateMembershipContentRequest model)
        {
            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.MembershipSubHeader))
            {
                content.MembershipSubHeader = model.MembershipSubHeader;
            }

            if (!string.IsNullOrEmpty(model.MemberShipName1))
            {
                content.MemberShipName1 = model.MemberShipName1;
            }

            if (!string.IsNullOrEmpty(model.Membership1Amount1))
            {
                content.Membership1Amount1 = model.Membership1Amount1;
            }

            if (!string.IsNullOrEmpty(model.Membership1Amount2))
            {
                content.Membership1Amount2 = model.Membership1Amount2;
            }

            if (!string.IsNullOrEmpty(model.Membership1Amount3))
            {
                content.Membership1Amount3 = model.Membership1Amount3;
            }

            if (!string.IsNullOrEmpty(model.MemberShipName2))
            {
                content.MemberShipName2 = model.MemberShipName2;
            }

            if (!string.IsNullOrEmpty(model.Membership2Amount1))
            {
                content.Membership2Amount1 = model.Membership2Amount1;
            }

            if (!string.IsNullOrEmpty(model.Membership2Amount2))
            {
                content.Membership2Amount2 = model.Membership2Amount2;
            }

            if (!string.IsNullOrEmpty(model.Membership2Amount3))
            {
                content.Membership2Amount3 = model.Membership2Amount3;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            return Ok(content); 
        }


        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> UpdateScholarshipContent(UpdateScholarshipContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.ScholarshipSubHeader))
            {
                content.ScholarshipSubHeader = model.ScholarshipSubHeader;
            }

            if (!string.IsNullOrEmpty(model.ScholarshipLine1))
            {
                content.ScholarshipLine1 = model.ScholarshipLine1;
            }

            if (!string.IsNullOrEmpty(model.ScholarshipDocumentName1))
            {
                content.ScholarshipDocumentName1 = model.ScholarshipDocumentName1;
            }

            if (!string.IsNullOrEmpty(model.ScholarshipDocumentName2))
            {
                content.ScholarshipDocumentName2 = model.ScholarshipDocumentName2;
            }

            if (!string.IsNullOrEmpty(model.ScholarshipDocumentName3))
            {
                content.ScholarshipDocumentName3 = model.ScholarshipDocumentName3;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            return Ok(content);
        }


        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> UpdateAboutUsContent(UpdateAboutUsContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.AboutUsSubHeader))
            {
                content.AboutUsSubHeader = model.AboutUsSubHeader;
            }

            if (!string.IsNullOrEmpty(model.AboutUsQuote))
            {
                content.AboutUsQuote = model.AboutUsQuote;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            return Ok(content);
        }

        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> UpdateContactUsContent(UpdateContactUsContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.ContactUsSubHeader))
            {
                content.ContactUsSubHeader = model.ContactUsSubHeader;
            }

            if (!string.IsNullOrEmpty(model.ContactUsAddressName1))
            {
                content.ContactUsAddressName1 = model.ContactUsAddressName1;
            }

            if (!string.IsNullOrEmpty(model.ContactUsAddressName2))
            {
                content.ContactUsAddressName2 = model.ContactUsAddressName2;
            }


            if (!string.IsNullOrEmpty(model.ContactUsStreetAddress))
            {
                content.ContactUsStreetAddress = model.ContactUsStreetAddress;
            }


            if (!string.IsNullOrEmpty(model.ContactUsCityStateZip))
            {
                content.ContactUsCityStateZip = model.ContactUsCityStateZip;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            return Ok(content);
        }
        #endregion
    }
}
