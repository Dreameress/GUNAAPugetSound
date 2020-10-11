using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Content
{
    public class UpdateAboutUsContentRequest : BaseModel<UpdateAboutUsContentRequest>
    {
        [Required]
        public Guid Id { get; set; }
        public string AboutUsHeader { get; set; }
        public string AboutUsSubHeader { get; set; }
        public string AboutUsQuoteLine1 { get; set; }
        public string AboutUsQuoteLine2 { get; set; }
        public string AboutUsQuoteLine3 { get; set; }
        public string AboutUsQuoteLine4 { get; set; }
    }
}
