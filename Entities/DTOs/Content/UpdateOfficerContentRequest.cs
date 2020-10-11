using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Content
{
    public class UpdateOfficerContentRequest : BaseModel<UpdateOfficerContentRequest>
    {
        [Required]
        public Guid Id { get; set; }
        public string OfficersMainHeader { get; set; }
        public string OfficersSubHeader { get; set; }
    }
}
