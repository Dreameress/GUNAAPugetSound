using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DTOs.Events;
using Entities.DTOs.Officers;
using Entities.Models;
using GUNAAPugetSound.Entities.Enums;
using GUNAAPugetSound.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GUNAAPugetSound.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficersController : BaseController
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public OfficersController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper, IEmailService emailService)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id:Guid}")]
        public ActionResult<OfficerResponse> GetById(Guid id)
        {

            var officer = _mapper.Map<OfficerResponse>(_repository.Officer.GetOfficerById(id));
            return Ok(officer);
        }

        [HttpGet("{id:int}")]
        public ActionResult<OfficerResponse> GetByMemberId(int id)
        {

            var officer = _mapper.Map<OfficerResponse>(_repository.Officer.GetOfficerByMemberId(id));
            return Ok(officer);
        }

        [HttpGet]
        public ActionResult<IEnumerable<OfficerResponse>> GetAllOfficers()
        {
            var officers = _mapper.Map<IList<OfficerResponse>>(_repository.Officer.GetAllOfficers());
            return Ok(officers);
        }

        [HttpGet]
        public ActionResult<IEnumerable<OfficerResponse>> GetActiveOfficers()
        {
            var officers = _mapper.Map<IList<OfficerResponse>>(_repository.Officer.GetActiveOfficers());
            return Ok(officers);
        }

        [Helpers.Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<EventsResponse> AddOfficer(AddOfficerRequest model)
        {
            // only admins can create albums
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });
            // map model to new account object
            var officer = _mapper.Map<Officer>(model);
            // validate
            if (_repository.Officer.OfficerWithRoleExists(model.Role))
                throw new AppException($"This Officer Role is currently occupied.");

            _repository.Officer.AddOfficer(ref officer, Account.Id, model.MemberId);
            var officerResponse = _mapper.Map<OfficerResponse>(officer);
            return Ok(officerResponse);
        }

        [Helpers.Authorize(Role.Admin)]
        [HttpPut]
        public ActionResult<EventsResponse> Update(UpdateOfficerRequest model)
        {
            // only admins can update events
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var officer = _repository.Officer.GetOfficerById(model.Id);

            // copy model to account and save
            _mapper.Map(model, officer);

            _repository.Officer.UpdateOfficer(ref officer, Account.Id, model.MemberId);
            var officerResponse = _mapper.Map<OfficerResponse>(officer);
            return Ok(officerResponse);
        }

        [Helpers.Authorize(Role.Admin)]
        [HttpDelete("{id:Guid}")]
        public IActionResult DeactivateOfficer(Guid id)
        {
            // users can delete their own account and admins can delete any account
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var officer = _repository.Officer.GetOfficerById(id);
            _repository.Officer.DeactivateOfficer(officer, Account.Id);
            return Ok(new { message = "Officer deactivated successfully" });
        }

    }
}
