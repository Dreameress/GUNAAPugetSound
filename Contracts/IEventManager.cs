﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace Contracts
{
    public interface IEventManager : IRepositoryBase<Event>
    {
        IEnumerable<Event> GetByDateRange(DateTime start, DateTime end);
        IEnumerable<Event> GetByMonth(int month, int? year);
        IEnumerable<Event> GetByYear(int year);
        Event GetById(Guid id);
        IEnumerable<Event> GetAllEvents();
        bool Exists(Event calendarEvent);
        void CreateEvent(ref Event calendarEvent, int accountId);
        void UpdateEvent(ref Event calendarEvent, int accountId);
        void DeleteEvent(Event calendarEvent);
    }
}
