using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Models;
using GUNAAPugetSound.Entities;
using GUNAAPugetSound.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GUNAAPugetSound.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class MembersController : Controller
    {
        public List<Member> MemberData => new[]
        {
            new Member {NameFirst = "Charlene", NameLast = "F Davidson Jenkins", MemberId = Guid.NewGuid(), Position = OfficerRole.President.ToString()},
            new Member
            {NameFirst = "Jeanie", NameLast = "Nelson", Position = OfficerRole.Secretary.ToString()},
            new Member{NameFirst = "Eva", NameLast = "Edwards", Position = OfficerRole.Treasurer.ToString(), Committee = CommitteeName.Hospitality.ToString()},
            new Member{NameFirst = "Beverly", NameLast = "Hopkins", Position = OfficerRole.Parliamentarian.ToString()},
            new Member{NameFirst = "TBD", NameLast = "", Position = OfficerRole.VicePresident.ToString()},
            new Member{NameFirst = "Marcus", NameLast = "Dabney", Position = OfficerRole.None.ToString(), Committee = CommitteeName.ScholarshipChair.ToString()},
            new Member{NameFirst = "Don", NameLast = "Paul", Position = OfficerRole.None.ToString(),Committee = CommitteeName.Fundraising.ToString()},
            new Member{NameFirst = "Tammy",NameLast = "Richardson",Position = OfficerRole.None.ToString(),Committee = CommitteeName.Membership.ToString()}

        }.ToList();

        [HttpGet("[action]")]
        public IEnumerable<Member> Members()
        {
            return MemberData;
        }

        [HttpGet("[action]")]
        public IEnumerable<Member> Officers(int startDateIndex)
        {
            return MemberData.OrderBy(x => x.Position).Where(y => y.Position != OfficerRole.None.ToString());
        }

        [HttpGet("[action]")]
        public IEnumerable<Member> CommitteeMembers(int startDateIndex)
        {
            return MemberData.Where(r => r.Committee != CommitteeName.None.ToString());
        }
    }
}
