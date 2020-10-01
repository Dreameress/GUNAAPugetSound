﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUNAAPugetSound.Models.Photos
{
    public class CreateAlbumRequest 
    {
        public Guid Id { get; set; }

        [Required, MaxLength(160)]
        [Display(Name = "Album Name")]
        public string Name { get; set; }

        [Required, MaxLength(200)]
        [Display(Name = "Album Description")]
        public string Description { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime EditTime { get; set; }
        [Required, MaxLength(160)]
        public string CreatedBy { get; set; }

        public string LastEditBy { get; set; }
    }
}
