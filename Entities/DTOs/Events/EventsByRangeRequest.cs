using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Events
{
    public class EventsByRangeRequest : BaseModel<EventsByRangeRequest>
    {
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
    }
}
