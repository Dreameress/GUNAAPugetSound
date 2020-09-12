using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GUNAAPugetSound.Utilities;

namespace GUNAAPugetSound.Models
{
    public class Album : Validation.IValidatable
    {
        public Guid Id { get; set; }

        [Required, MaxLength(160)]
        [Display(Name = "Album Name")]
        public string AlbumName { get; set; }

        [Required, MaxLength(200)]
        [Display(Name = "Album Description")]
        public string AlbumDesc { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime EditTime { get; set; }
        [Required, MaxLength(160)]
        public string CreatedBy { get; set; }

        public string LastEditBy { get; set; }
        Album() { }

        //come back here and modify so that author is collected once member registration is formed
        public Album(string name, string desc, string createdBy, string lastEditBy = "")
        {
            AlbumName = name;
            AlbumDesc = desc;
            CreateTime = DateTime.Now;
            EditTime = DateTime.Now;
            CreatedBy = createdBy;
            LastEditBy = lastEditBy;
            Id = Randomness.Guid();
            this.EnforceValidity();
        }

        public Album(string name, string desc, string lastEditBy)
        {
            AlbumName = name;
            AlbumDesc = desc;
            EditTime = DateTime.Now;
            LastEditBy = lastEditBy;
        }


    }
}