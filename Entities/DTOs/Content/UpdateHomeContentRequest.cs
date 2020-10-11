using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Content
{
    public class UpdateHomeContentRequest : BaseModel<UpdateHomeContentRequest>
    {
        [Required]
        public Guid Id { get; set; }
        public string HomeMainHeader { get; set; }
        public string HomeSubHeader { get; set; }
        public string HomeLine1 { get; set; }
        public string HomeLine2 { get; set; }
        public string HomeLine3 { get; set; }
        public string HomeLine4 { get; set; }
    }
}
