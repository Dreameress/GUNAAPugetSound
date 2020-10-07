
using Entities.DTOs.Content;
using GUNAAPugetSound.Entities.Enums;
using GUNAAPugetSound.Services;
using Microsoft.AspNetCore.Mvc;

namespace GUNAAPugetSound.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : BaseController
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        #region Get Content
        [HttpGet]
        public ActionResult<ContentResponse> GetContent(int id, ContentRequest model)
        {
            ContentResponse content = _contentService.GetContent(model);
            return Ok(content);
        }

        [HttpGet]
        public ActionResult<OfficerContentResponse> GetOfficerContent(int id, ContentRequest model)
        {
            OfficerContentResponse content = _contentService.GetOfficerContent(model);
            return Ok(content);
        }

        [HttpGet]
        public ActionResult<CommitteeContentResponse> GetCommitteeContent(int id, ContentRequest model)
        {
            CommitteeContentResponse content = _contentService.GetCommitteeContent(model);
            return Ok(content);
        }


        [HttpGet]
        public ActionResult<MembershipContentResponse> GetMembershipContent(ContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            MembershipContentResponse content = _contentService.GetMembershipContent(model);
            return Ok(content);
        }

        [HttpGet]
        public ActionResult<ScholarshipContentResponse> GetScholarshipContent(ContentRequest model)
        {
            ScholarshipContentResponse content = _contentService.GetScholarshipContent(model);
            return Ok(content);
        }

        [HttpGet]
        public ActionResult<ContactUsContentResponse> GetContactUsContent(ContentRequest model)
        {
            ContactUsContentResponse content = _contentService.GetContactUsContent(model);
            return Ok(content);
        }

        [HttpGet]
        public ActionResult<AboutUsContentResponse> GetAboutUsContent(ContentRequest model)
        {
            AboutUsContentResponse content = _contentService.GetAboutUsContent(model);
            return Ok(content);
        }

        #endregion



        #region Update Content

        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> Update(int id, UpdateContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _contentService.UpdateContent(id, model);
            return Ok(account);
        }

        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> UpdateOfficerContent(UpdateOfficerContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _contentService.UpdateOfficerContent(model);
            return Ok(account);
        }


        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> UpdateCommitteeContent(UpdateCommitteeContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _contentService.UpdateCommitteeContent(model);
            return Ok(account);
        }


        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> UpdateMembershipContent(UpdateMembershipContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _contentService.UpdateMembershipContent(model);
            return Ok(account);
        }


        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> UpdateScholarshipContent(UpdateScholarshipContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _contentService.UpdateScholarshipContent(model);
            return Ok(account);
        }


        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> UpdateAboutUsContent(UpdateAboutUsContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _contentService.UpdateAboutUsContent(model);
            return Ok(account);
        }

        [Helpers.Authorize(Role.Admin)]
        [HttpPut("{id:int}")]
        public ActionResult<ContentResponse> UpdateContactUsContent(UpdateContactUsContentRequest model)
        {

            // only admins can update content
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _contentService.UpdateContactUsContent(model);
            return Ok(account);
        }
        #endregion
    }
}
