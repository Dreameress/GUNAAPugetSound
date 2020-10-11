using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DTOs.Accounts;
using Entities.DTOs.Events;
using Entities.Models;
using GUNAAPugetSound.Entities.Enums;
using GUNAAPugetSound.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GUNAAPugetSound.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : BaseController
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public EventsController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper, IEmailService emailService)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
       

        [HttpGet("{id:Guid}")]
        public ActionResult<EventsResponse> GetById(Guid id)
        {

            var account = _mapper.Map<EventsResponse>(_repository.Event.GetById(id));
            return Ok(account);
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventsResponse>> GetAll()
        {
            var accounts = _mapper.Map<IList<EventsResponse>>(_repository.Event.GetAllEvents());
            return Ok(accounts);
        }


        [HttpGet]
        public ActionResult<IEnumerable<EventsResponse>> GetByDateRange(EventsByRangeRequest model)
        {
            var accounts = _mapper.Map<IList<EventsResponse>>(_repository.Event.GetByDateRange(model.Start, model.End));
            return Ok(accounts);
        }


        [HttpGet]
        public ActionResult<IEnumerable<EventsResponse>> GetByMonth(EventsByMonthRequest model)
        {
            var accounts = _mapper.Map<IList<EventsResponse>>(_repository.Event.GetByMonth(model.Month, model.Year));
            return Ok(accounts);
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventsResponse>> GetByYear(EventsByYearRequest model)
        {
            var accounts = _mapper.Map<IList<EventsResponse>>(_repository.Event.GetByYear(model.Year));
            return Ok(accounts);
        }


        [Helpers.Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<EventsResponse> Create(CreateEventRequest model)
        { 
            // only admins can create albums
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });
            // map model to new account object
            var calendarEvent = _mapper.Map<Event>(model);
            // validate
            if (_repository.Event.Exists(calendarEvent))
                throw new AppException($"Event overlaps existing events.");

            _repository.Event.CreateEvent(ref calendarEvent, Account.Id);
            var eventResponse = _mapper.Map<EventsResponse>(calendarEvent);
            return Ok(eventResponse);
        }

        [Helpers.Authorize(Role.Admin)]
        [HttpPut]
        public ActionResult<EventsResponse> Update(UpdateEventRequest model)
        {
            // only admins can update events
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var calendarEvent = _repository.Event.GetById(model.Id);
            // validate
            if(_repository.Event.Exists(calendarEvent))
                throw new AppException($"Event overlaps existing events.");

            // copy model to account and save
            _mapper.Map(model, calendarEvent);

            _repository.Event.UpdateEvent(ref calendarEvent, Account.Id);
            var accountResponse = _mapper.Map<EventsResponse>(calendarEvent);
            return Ok(accountResponse);
        }

        [Helpers.Authorize(Role.Admin)]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(Guid id)
        {
            // users can delete their own account and admins can delete any account
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var calendarEvent = _repository.Event.GetById(id);
            _repository.Event.DeleteEvent(calendarEvent);
            return Ok(new { message = "Event deleted successfully" });
        }
    }
}
