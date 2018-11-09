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

        [Required]
        public String Description { get; set; }

        public String ImagePath { get; set; }

        public String ThumbPath { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AddedBy { get; set; }

        [NotMapped]
        public List<string> PhotoList { get; set; }


        public Photo() { }

        public Photo(Guid albumId)
        {
            AlbumId = albumId;
            Id = Randomness.Guid();
        }

        public Photo(Guid albumId, string description, string imagePath, string thumbPath, string createdBy)
        {
            Description = description;
            AlbumId = albumId;
            ThumbPath = thumbPath;
            ImagePath = imagePath;
            CreatedOn = DateTime.Now;
            AddedBy = createdBy;
            Id = Randomness.Guid();
        }
    }
}