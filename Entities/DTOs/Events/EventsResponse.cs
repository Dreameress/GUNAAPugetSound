using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Events
{
    public class EventsResponse : BaseModel<EventsResponse>
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public string Description { get; set; }
        public DateTime Created { get; set; }

        public int CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public int UpdatedBy { get; set; }
    }
}
