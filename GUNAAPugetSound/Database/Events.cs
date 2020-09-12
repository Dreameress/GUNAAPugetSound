using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GUNAAPugetSound.Utilities;

namespace GUNAAPugetSound.Models
{
    public class Event : Validation.IValidatable
    {
        public Guid Id { get; set; }
        public int MemberId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        public string StartTime { get; set; }
        
        public string EndTime { get; set; }

        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public string Type { get; set; }

        Event()
        {
        }

        //come back here and modify so that author is collected once member registration is formed
        public Event(string start, string end, string title, string desc)
        {
            Title = title;
            StartDate = start;
            EndDate = end;
            Description = desc;
            Id = Randomness.Guid();
            this.EnforceValidity();
        }
    }
}
