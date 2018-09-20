using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUNAAPugetSound.Models;
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
            new Member
                ("Charlene", "F Davidson Jenkins", OfficerPosition.President),
            new Member("Jeanie", "Nelson", OfficerPosition.Secretary),
            new Member("Eva", "Edwards", OfficerPosition.Treasurer, CommitteeName.Hospitality),
            new Member("Beverly", "Hopkins", OfficerPosition.Parliamentarian),
            new Member("TBD", "", OfficerPosition.VicePresident),
            new Member("Marcus", "Dabney", OfficerPosition.None, CommitteeName.ScholarshipChair),
            new Member("Don", "Paul", OfficerPosition.None, CommitteeName.Fundraising),
            new Member("Tammy", "Richardson", OfficerPosition.None, CommitteeName.Membership)

        }.ToList();

        [HttpGet("[action]")]
        public IEnumerable<Member> Members()
        {
            return MemberData;
        }

        [HttpGet("[action]")]
        public IEnumerable<Member> Officers(int startDateIndex)
        {
            return MemberData.OrderBy(x => x.Position).Where(y => y.Position != OfficerPosition.None.ToString());
        }

        [HttpGet("[action]")]
        public IEnumerable<Member> CommitteeMembers(int startDateIndex)
        {
            return MemberData.Where(r => r.Committee != CommitteeName.None.ToString());
        }
    }
}
