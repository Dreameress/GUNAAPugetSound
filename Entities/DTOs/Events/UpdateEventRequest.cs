using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Events
{
    public class UpdateEventRequest : BaseModel<UpdateEventRequest>
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public string Description { get; set; }
    }
}
