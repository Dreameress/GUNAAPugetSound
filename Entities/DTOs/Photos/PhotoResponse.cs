using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.DTOs.Photos
{
    public class PhotoResponse : BaseModel<PhotoResponse>
    {
        public Guid Id { get; set; }

        public Guid AlbumId { get; set; }

        public String Description { get; set; }

        public String ImagePath { get; set; }

        public String ThumbPath { get; set; }

        public DateTime Created { get; set; }

        public int AddedBy { get; set; }
    }
}
