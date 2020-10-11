using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Album
    {
        [Key]
        public Guid AlbumId { get; set; }

        [Required, MaxLength(160)]
        [Display(Name = "Album Name")]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        [Display(Name = "Album Description")]
        public string Description { get; set; }
        [Required]
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
        [Required]
        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set; }
    }
}