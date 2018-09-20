using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUNAAPugetSound.ViewModels;

namespace GUNAAPugetSound.DTOs
{
    public class AlbumDto
    {
        public UserDto User { get; set; }
        public AlbumEditViewModel Model { get; set; }
        public Guid? Guid { get; set; }
    }

    public class DeleteDto
    {
        public DeleteModel Guid { get; set; }
    }


    public class DeleteModel
    {
        public string Id { get; set; }
    }
}