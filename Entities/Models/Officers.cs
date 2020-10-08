using System;
using GUNAAPugetSound.Entities.Enums;

namespace Entities.Models
{
    public class Officer
    {
        public int Id { get; set; }
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
