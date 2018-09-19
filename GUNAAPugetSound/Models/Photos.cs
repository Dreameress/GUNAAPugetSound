using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GUNAAPugetSound.Utilities;

namespace GUNAAPugetSound.Models
{
    public class Photo
    {
        public Guid Id { get; set; }

        public Guid AlbumId { get; set; }

        [Display(Name = "Decription")]
        [Required]
        public String Description { get; set; }

        [Display(Name = "Image Path")]
        public String ImagePath { get; set; }

        [Display(Name = "Thumb Path")]
        public String ThumbPath { get; set; }


        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [NotMapped]
        public List<string> PhotoList { get; set; }


        public Photo() { }

        public Photo(Guid albumId)
        {
            AlbumId = albumId;
            Id = Randomness.Guid();
        }

        public Photo(Guid albumId, string description, string imagePath, string thumbPath, string createdBy = "Sabrina Smith")
        {
            Description = description;
            AlbumId = albumId;
            ThumbPath = thumbPath;
            ImagePath = imagePath;
            CreatedOn = DateTime.Now;
            Id = Randomness.Guid();
        }
    }
}