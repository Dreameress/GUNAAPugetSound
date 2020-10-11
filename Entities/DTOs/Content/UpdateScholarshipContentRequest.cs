using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Content
{
    public class UpdateScholarshipContentRequest : BaseModel<UpdateScholarshipContentRequest>
    {
        [Required]
        public Guid Id { get; set; }
        public string ScholarshipMainHeader { get; set; }
        public string ScholarshipSubHeader { get; set; }
        public string ScholarshipLine1 { get; set; }
    }
}
