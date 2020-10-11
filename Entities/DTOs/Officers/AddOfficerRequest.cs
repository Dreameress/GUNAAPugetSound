using System;
using System.Collections.Generic;
using System.Text;
using GUNAAPugetSound.Entities.Enums;

namespace Entities.DTOs.Officers
{
    public class AddOfficerRequest : BaseModel<AddOfficerRequest>
    {
        public OfficerRole Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? MemberId { get; set; }
    }
}
