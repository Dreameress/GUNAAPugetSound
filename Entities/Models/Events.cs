using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Event 
    {
        [Key]
        public Guid EventId { get; set; }

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
