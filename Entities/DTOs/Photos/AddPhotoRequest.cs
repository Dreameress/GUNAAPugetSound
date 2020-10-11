using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.Photos
{
    public class AddPhotoRequest : BaseModel<AddPhotoRequest>
    {
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        [Required]
        public Guid AlbumId { get; set; }
        [Required]
        public String Description { get; set; }
        [Required]
        public String ImagePath { get; set; }
        [Required]
        public String ThumbPath { get; set; }
    }
}
