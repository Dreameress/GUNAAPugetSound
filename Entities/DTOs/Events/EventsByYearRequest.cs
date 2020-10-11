using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Events
{
    public class EventsByYearRequest : BaseModel<EventsByYearRequest>
    {
        [Required]
        public int Year { get; set; }
    }
}
