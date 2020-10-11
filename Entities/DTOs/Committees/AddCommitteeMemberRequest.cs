using GUNAAPugetSound.Entities.Enums;

namespace Entities.DTOs.Committees
{
    public class AddCommitteeMemberRequest : BaseModel<AddCommitteeMemberRequest>
    {
        public CommitteeName Committee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? MemberId { get; set; }
    }
}
