using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using GUNAAPugetSound.Utilities;
using Microsoft.AspNetCore.Http;

namespace GUNAAPugetSound.Models.Photos
{
    public class AddPhotoRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        [Required]
        public Guid AlbumId { get; set; }
        [Required]
        public String Description { get; set; }
        //public String ImagePath { get; set; }
        //public String ThumbPath { get; set; }
    }
}
