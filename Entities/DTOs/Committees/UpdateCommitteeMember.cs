using System;

namespace Entities.DTOs.Committees
{
    public class UpdateCommitteeMember : BaseModel<UpdateCommitteeMember>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? MemberId { get; set; }
    }
}
