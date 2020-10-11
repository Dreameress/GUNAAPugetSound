using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Photos
{
    public class CreatePhotoAlbumRequest : BaseModel<CreatePhotoAlbumRequest>
    {
        [Required, MaxLength(160)]
        [Display(Name = "Album Name")]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        [Display(Name = "Album Description")]
        public string Description { get; set; }
    }
}
