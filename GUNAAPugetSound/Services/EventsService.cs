using System;
using System.Collections.Generic;
using Entities.DTOs.Events;

namespace GUNAAPugetSound.Services
{
    public interface IEventsService
    {
        IEnumerable<EventsResponse> GetAll();
        IEnumerable<EventsResponse> GetByDateRange(DateTime start, DateTime end);
        IEnumerable<EventsResponse> GetByMonth(string month, string year = null);
        IEnumerable<EventsResponse> GetByYear(int year);
        EventsResponse GetById(int id);
        EventsResponse Create(CreateEventRequest model);
        EventsResponse Update(UpdateEventRequest model);
        void Delete(int id);

    }

    public class EventsService : IEventsService
    {
        public IEnumerable<EventsResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventsResponse> GetByDateRange(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventsResponse> GetByMonth(string month, string year = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventsResponse> GetByYear(int year)
        {
            throw new NotImplementedException();
        }

        public EventsResponse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public EventsResponse Create(CreateEventRequest model)
        {
            throw new NotImplementedException();
        }

        public EventsResponse Update(UpdateEventRequest model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
