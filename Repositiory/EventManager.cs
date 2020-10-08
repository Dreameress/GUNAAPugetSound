using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Entities.Models;
using GUNAAPugetSound.Entities;
using Microsoft.VisualBasic;

namespace Repository
{
    class EventManager : RepositoryBase<Event>, IEventManager
    {
        public EventManager(GUNAADbContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public IEnumerable<Event> GetByDateRange(DateTime start, DateTime end)
        {
            return RepositoryContext.Events.Where(e => e.Start.Date >= start.Date && e.End.Date <= end.Date);
        }

        public IEnumerable<Event> GetByMonth(int month, int? year = null)
        {
            year ??= DateTime.Now.Year;
            return RepositoryContext.Events.Where(e => e.Start.Month == month && e.Start.Year == year);
        }

        public IEnumerable<Event> GetByYear(int year)
        {
            return RepositoryContext.Events.Where(e => e.Start.Year == year);
        }

        public Event GetById(int id)
        {
            return RepositoryContext.Events.Find(id);
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return RepositoryContext.Events;
        }

        public void CreateEvent(Event calendarEvent, int accountId)
        {
            calendarEvent.Created = DateTime.UtcNow;
            calendarEvent.CreatedBy = accountId;
            RepositoryContext.Events.Add(calendarEvent);
            RepositoryContext.SaveChanges();

        }

        public void UpdateEvent(Event calendarEvent, int accountId)
        {
            calendarEvent.Updated = DateTime.UtcNow;
            calendarEvent.UpdatedBy = accountId;
            RepositoryContext.Events.Update(calendarEvent);
            RepositoryContext.SaveChanges();

        }

        public void DeleteEvent(Event calendarEvent)
        {
            RepositoryContext.Events.Remove(calendarEvent);
            RepositoryContext.SaveChanges();
        }
    }
}
