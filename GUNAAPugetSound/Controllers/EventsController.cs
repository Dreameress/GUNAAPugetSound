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
        private readonly AppSettings _appSettings;

        public EventsController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper, AppSettings appSettings, IEmailService emailService)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _appSettings = appSettings;
        }
       

        [Helpers.Authorize]
        [HttpGet("{id:int}")]
        public ActionResult<EventsResponse> GetById(int id)
        {
            // users can get their own account and admins can get any account
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _repository.Account.GetById(id);
            return Ok(account);
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventsResponse>> GetAll()
        {
            var accounts = _mapper.Map<IList<EventsResponse>>(_repository.Event.GetAllEvents());
            return Ok(accounts);
        }


        [HttpGet]
        public ActionResult<IEnumerable<EventsResponse>> GetByDateRange(DateTime start, DateTime end)
        {
            var accounts = _mapper.Map<IList<EventsResponse>>(_repository.Event.GetByDateRange(start, end));
            return Ok(accounts);
        }


        [HttpGet]
        public ActionResult<IEnumerable<EventsResponse>> GetByMonth(int month, int? year)
        {
            var accounts = _mapper.Map<IList<EventsResponse>>(_repository.Event.GetByMonth(month, year));
            return Ok(accounts);
        }

        [HttpGet]
        public ActionResult<IEnumerable<EventsResponse>> GetByYear(int year)
        {
            var accounts = _mapper.Map<IList<EventsResponse>>(_repository.Event.GetByYear(year));
            return Ok(accounts);
        }


        [Helpers.Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<EventsResponse> Create(CreateEventRequest model)
        {
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
        [HttpPut("{id:int}")]
        public ActionResult<EventsResponse> Update(int id, UpdateEventRequest model)
        {
            // only admins can update events
            if (Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var calendarEvent = _repository.Event.GetById(id);
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
        public IActionResult Delete(int id)
        {
            // users can delete their own account and admins can delete any account
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var calendarEvent = _repository.Event.GetById(id);
            _repository.Event.Delete(calendarEvent);
            return Ok(new { message = "Event deleted successfully" });
        }


    }
}
