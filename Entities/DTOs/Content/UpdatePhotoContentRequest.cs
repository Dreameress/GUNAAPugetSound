using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTOs.Content
{
    public class UpdatePhotoContentRequest : BaseModel<UpdatePhotoContentRequest>
    {
        [Required]
        public Guid Id { get; set; }
        public string PhotoMainHeader { get; set; }
        public string PhotoSubHeader { get; set; }
    }
}
