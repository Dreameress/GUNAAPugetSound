
using System.Collections;
using System.Linq;
using AutoMapper;
using Contracts;
using Entities.DTOs.Content;
using GUNAAPugetSound.Entities.Enums;
using GUNAAPugetSound.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GUNAAPugetSound.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : BaseController
    {
        private ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ContentController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper, IEmailService emailService)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        #region Get Content
        [HttpGet("get-content")]
        public ActionResult<ContentResponse> GetContent()
        {
            var content = _mapper.Map<ContentResponse>(
                           new ContentResponse
            {
                Content = _repository.Content.GetContent(),
                Officers = _repository.Officer.GetActiveOfficers().ToList(),
                CommitteeMembers = _repository.CommitteeMember.GetActiveCommitteeMembers().ToList(),
                Events = _repository.Event.GetAllEvents().ToList(),
                Albums = _repository.Album.GetAllAlbums().ToList()
            });
            _logger.LogInfo("Returned content from database");
            return Ok(content);
        }
        #endregion



        #region Update Content

        [Authorize(Role.Admin)]
        [HttpPut("update-home")]
        public ActionResult<ContentResponse> UpdateHomeContent(UpdateHomeContentRequest model)
        {
            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.HomeMainHeader))
            {
                content.HomeMainHeader = model.HomeMainHeader;
            }

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

            if (!string.IsNullOrEmpty(model.HomeLine4))
            {
                content.HomeLine4 = model.HomeLine4;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            _logger.LogInfo("Updated home view content");
            return Ok(content);
        }

        [Authorize(Role.Admin)]
        [HttpPut("update-calendar")]
        public ActionResult<ContentResponse> UpdateCalendarContent(UpdateCalendarContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.CalendarMainHeader))
            {
                content.CalendarMainHeader = model.CalendarMainHeader;
            }

            if (!string.IsNullOrEmpty(model.CalendarSubHeader))
            {
                content.CalendarSubHeader = model.CalendarSubHeader;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            _logger.LogInfo("Updated calendar view content");
            return Ok(content);
        }

        [Authorize(Role.Admin)]
        [HttpPut("update-officer")]
        public ActionResult<ContentResponse> UpdateOfficerContent(UpdateOfficerContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();

            if (!string.IsNullOrEmpty(model.OfficersMainHeader))
            {
                content.OfficersMainHeader = model.OfficersMainHeader;
            }

            if (!string.IsNullOrEmpty(model.OfficersSubHeader))
            {
                content.OfficersSubHeader = model.OfficersSubHeader;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            _logger.LogInfo("Updated officer view content");
            return Ok(content);
        }


        [Authorize(Role.Admin)]
        [HttpPut("update-committee")]
        public ActionResult<ContentResponse> UpdateCommitteeContent(UpdateCommitteeContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.CommitteesMainHeader))
            {
                content.CommitteesMainHeader = model.CommitteesMainHeader;
            }

            if (!string.IsNullOrEmpty(model.CommitteesSubHeader))
            {
                content.CommitteesSubHeader = model.CommitteesSubHeader;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            _logger.LogInfo("Updated committee view content");
            return Ok(content);
        }


        [Authorize(Role.Admin)]
        [HttpPut("update-membership")]

        public ActionResult<ContentResponse> UpdateMembershipContent(UpdateMembershipContentRequest model)
        {
            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.MembershipMainHeader))
            {
                content.MembershipMainHeader = model.MembershipMainHeader;
            }
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
            _logger.LogInfo("Updated membership view content");
            return Ok(content); 
        }


        [Authorize(Role.Admin)]
        [HttpPut("update-scholarship")]
        public ActionResult<ContentResponse> UpdateScholarshipContent(UpdateScholarshipContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.ScholarshipMainHeader))
            {
                content.ScholarshipMainHeader = model.ScholarshipMainHeader;
            }
            if (!string.IsNullOrEmpty(model.ScholarshipSubHeader))
            {
                content.ScholarshipSubHeader = model.ScholarshipSubHeader;
            }

            if (!string.IsNullOrEmpty(model.ScholarshipLine1))
            {
                content.ScholarshipLine1 = model.ScholarshipLine1;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            _logger.LogInfo("Updated scholarship view content");
            return Ok(content);
        }

        [Authorize(Role.Admin)]
        [HttpPut("update-photo")]
        public ActionResult<ContentResponse> UpdatePhotoAlbumContent(UpdatePhotoContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.PhotoMainHeader))
            {
                content.PhotoMainHeader = model.PhotoMainHeader;
            }

            if (!string.IsNullOrEmpty(model.PhotoSubHeader))
            {
                content.PhotoSubHeader = model.PhotoSubHeader;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            _logger.LogInfo("Updated photo album view content");
            return Ok(content);
        }


        [Authorize(Role.Admin)]
        [HttpPut("update-about")]
        public ActionResult<ContentResponse> UpdateAboutUsContent(UpdateAboutUsContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.AboutUsHeader))
            {
                content.AboutUsHeader = model.AboutUsHeader;
            }

            if (!string.IsNullOrEmpty(model.AboutUsSubHeader))
            {
                content.AboutUsSubHeader = model.AboutUsSubHeader;
            }

            if (!string.IsNullOrEmpty(model.AboutUsQuoteLine1))
            {
                content.AboutUsQuoteLine1 = model.AboutUsQuoteLine1;
            }
            if (!string.IsNullOrEmpty(model.AboutUsQuoteLine2))
            {
                content.AboutUsQuoteLine2 = model.AboutUsQuoteLine2;
            }

            if (!string.IsNullOrEmpty(model.AboutUsQuoteLine3))
            {
                content.AboutUsQuoteLine3 = model.AboutUsQuoteLine3;
            }

            if (!string.IsNullOrEmpty(model.AboutUsQuoteLine4))
            {
                content.AboutUsQuoteLine4 = model.AboutUsQuoteLine4;
            }
            _repository.Content.UpdateContent(ref content, Account.Id);
            _logger.LogInfo("Updated about us view content");
            return Ok(content);
        }

        [Authorize(Role.Admin)]
        [HttpPut("update-contact")]
        public ActionResult<ContentResponse> UpdateContactUsContent(UpdateContactUsContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var content = _repository.Content.GetContent();
            if (!string.IsNullOrEmpty(model.ContactUsHeader))
            {
                content.ContactUsHeader = model.ContactUsHeader;
            }

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

            if (!string.IsNullOrEmpty(model.ContactUsCity))
            {
                content.ContactUsCity = model.ContactUsCity;
            }

            if (!string.IsNullOrEmpty(model.ContactUsState))
            {
                content.ContactUsState = model.ContactUsState;
            }

            if (!string.IsNullOrEmpty(model.ContactUsZipCode))
            {
                content.ContactUsZipCode = model.ContactUsZipCode;
            }

            _repository.Content.UpdateContent(ref content, Account.Id);
            _logger.LogInfo("Updated contact us view content");
            return Ok(content);
        }
        #endregion
    }
}
