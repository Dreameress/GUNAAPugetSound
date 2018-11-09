using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUNAAPugetSound.ViewModels;
using Microsoft.AspNetCore.Http;

namespace GUNAAPugetSound.DTOs
{
    public class PhotoDto
    {
        public UserDto User { get; set; }
        public PhotoAlbumViewModel Model { get; set; }
        public IEnumerable<IFormFile> Files { get; set; }
        public Guid? Guid { get; set; }
    }

}