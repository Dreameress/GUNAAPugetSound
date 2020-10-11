using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Content
{
    public class UpdateCalendarContentRequest : BaseModel<UpdateCalendarContentRequest>
    {
        [Required]
        public Guid Id { get; set; }
        public string CalendarMainHeader { get; set; }
        public string CalendarSubHeader { get; set; }
    }
}
