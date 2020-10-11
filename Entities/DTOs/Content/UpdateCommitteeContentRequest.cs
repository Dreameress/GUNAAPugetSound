using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Content
{
    public class UpdateCommitteeContentRequest : BaseModel<UpdateCommitteeContentRequest>
    {
        [Required]
        public Guid Id { get; set; }
        public string CommitteesMainHeader { get; set; }
        public string CommitteesSubHeader { get; set; }
    }
}
