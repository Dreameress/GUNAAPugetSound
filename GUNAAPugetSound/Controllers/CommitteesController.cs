using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Contracts;
using Entities.DTOs.Committees;
using Entities.DTOs.Events;
using Entities.Models;
using GUNAAPugetSound.Entities.Enums;
using GUNAAPugetSound.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GUNAAPugetSound.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommitteesController : BaseController
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CommitteesController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper,
            IEmailService emailService)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id:Guid}")]
        public ActionResult<CommitteeMemberResponse> GetById(Guid id)
        {

            var member = _mapper.Map<CommitteeMemberResponse>(_repository.CommitteeMember.GetCommitteeMemberById(id));
            _logger.LogInfo("Returned committee member data from database");
            return Ok(member);
        }

        [HttpGet("{id:int}")]
        public ActionResult<CommitteeMemberResponse> GetByMemberId(int id)
        {

            var member = _mapper.Map<CommitteeMemberResponse>(_repository.CommitteeMember.GetCommitteeMemberByMemberId(id));
            _logger.LogInfo("Returned committee member data from database");
            return Ok(member);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommitteeMemberResponse>> GetAllCommitteeMembers()
        {
            var members = _mapper.Map<IList<CommitteeMemberResponse>>(_repository.CommitteeMember.GetAllCommitteeMembers().ToList());
            _logger.LogInfo("Returned list of committee member data from database");
            return Ok(members);
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommitteeMemberResponse>> GetActiveCommitteeMembers()
        {
            var members =
                _mapper.Map<IList<CommitteeMemberResponse>>(_repository.CommitteeMember.GetActiveCommitteeMembers().ToList());
            _logger.LogInfo("Returned active committee member data from database");
            return Ok(members);
        }

        [Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<EventsResponse> AddCommitteeMember(AddCommitteeMemberRequest model)
        {
            // only admins can create albums
            if (Account.Role != Role.Admin)
                return Unauthorized(new {message = "Unauthorized"});
            // map model to new account object
            var member = _mapper.Map<CommitteeMember>(model);

            _repository.CommitteeMember.CreateCommitteeMember(ref member, Account.Id, model.MemberId);
            _logger.LogInfo("Created committee member and added to database");
            var committeeMemberResponse = _mapper.Map<CommitteeMemberResponse>(member);
            return Ok(committeeMemberResponse);
        }

        [Authorize(Role.Admin)]
        [HttpPut]
        public ActionResult<EventsResponse> Update(UpdateCommitteeMember model)
        {
            // only admins can update events
            if (Account.Role != Role.Admin)
                return Unauthorized(new {message = "Unauthorized"});

            var member = _repository.CommitteeMember.GetCommitteeMemberById(model.Id);

            // copy model to account and save
            _mapper.Map(model, model);

            _repository.CommitteeMember.UpdateCommitteeMember(ref member, Account.Id, model.MemberId);
            _logger.LogInfo("Updated committee member data");
            var committeeMemberResponse = _mapper.Map<CommitteeMemberResponse>(member);
            return Ok(committeeMemberResponse);
        }

        [Authorize(Role.Admin)]
        [HttpDelete("{id:Guid}")]
        public IActionResult DeactivateCommitteeMember(Guid id)
        {
            // users can delete their own account and admins can delete any account
            if (Account.Role != Role.Admin)
                return Unauthorized(new {message = "Unauthorized"});

            var committeeMember = _repository.CommitteeMember.GetCommitteeMemberById(id);
            _logger.LogInfo("Returned committee member from database");
            _repository.CommitteeMember.DeactivateCommitteeMember(ref committeeMember, Account.Id);
            _logger.LogInfo("Deactivated committee member");
            return Ok(new {message = "CommitteeMember deactivated successfully"});
        }
    }
}