using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GUNAAPugetSound.Utilities;
using Microsoft.EntityFrameworkCore;

namespace GUNAAPugetSound.Entities
{
    public class Event 
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
    }
}
