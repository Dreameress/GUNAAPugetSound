using System;
using GUNAAPugetSound.Entities.Enums;

namespace Entities.DTOs.Committees
{
    public class CommitteeMemberResponse : BaseModel<CommitteeMemberResponse>
    {
        public Guid Id { get; set; }
        public CommitteeName Committee { get; set; }
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
