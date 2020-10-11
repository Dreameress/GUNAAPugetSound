using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Content
{
    public class UpdateContactUsContentRequest : BaseModel<UpdateContactUsContentRequest>
    {
        [Required]
        public Guid Id { get; set; }
        public string ContactUsHeader { get; set; }
        public string ContactUsSubHeader { get; set; }
        public string ContactUsAddressName1 { get; set; }
        public string ContactUsAddressName2 { get; set; }
        public string ContactUsStreetAddress { get; set; }
        public string ContactUsCity { get; set; }
        public string ContactUsState { get; set; }
        public string ContactUsZipCode { get; set; }
    }
}
