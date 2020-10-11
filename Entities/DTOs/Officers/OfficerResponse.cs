using System;
using System.Collections.Generic;
using System.Text;
using GUNAAPugetSound.Entities.Enums;

namespace Entities.DTOs.Officers
{
    public class OfficerResponse : BaseModel<OfficerResponse>
    {
        public Guid Id { get; set; }
        public OfficerRole Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public int? UpdatedBy { get; set; }
        public int? MemberId { get; set; }
    }
}
