using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Repository
{
    class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(GUNAARepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public IEnumerable<Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetByDateRange(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetByMonth(string month, string year = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetByYear(int year)
        {
            throw new NotImplementedException();
        }

        public Event GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            throw new NotImplementedException();
        }

        public void CreateEvent(Event calendarEvent, int accountId)
        {
            throw new NotImplementedException();
        }

        public void UpdateEvent(Event calendarEvent, int accountId)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvent(Event calendarEvent)
        {
            throw new NotImplementedException();
        }
    }
}
