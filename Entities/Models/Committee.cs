using System;
using GUNAAPugetSound.Entities.Enums;

namespace Entities.Models
{
    public class CommitteeMember
    {
        public int Id { get; set; }
        public CommitteeName Name { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public int UpdatedBy { get; set; }
        public int? MemberId { get; set; }
    }
}