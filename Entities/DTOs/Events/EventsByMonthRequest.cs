using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Events
{
    public class EventsByMonthRequest : BaseModel<EventsByMonthRequest>
    {   
        [Required, StringLength(2)]
        public int Month { get; set; }
        [Required, StringLength(4)]
        public int? Year { get; set; }
    }
}
