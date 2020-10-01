using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GUNAAPugetSound.Utilities;
using Microsoft.AspNetCore.Http;

namespace GUNAAPugetSound.Entities
{
    public class Photo 
    {
        public Guid Id { get; set; }

        public Guid AlbumId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [Required]
        public String Description { get; set; }

        public String ImagePath { get; set; }

        public String ThumbPath { get; set; }

        public DateTime Created { get; set; }

        public int AddedBy { get; set; }
    }
}