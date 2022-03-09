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
            new Member
            {
                NameFirst = "Charlene", 
                NameLast = "F Davidson Jenkins", 
                MemberId = Guid.NewGuid(), 
                Position = OfficerRole.President.ToString(), 
                OfficerRole = OfficerRole.President
            },
            new Member
            {
                NameFirst = "Jeanie", 
                NameLast = "Nelson", 
                Position = OfficerRole.Secretary.ToString(), 
                OfficerRole = OfficerRole.Secretary
            },
            new Member
            {
                NameFirst = "Eva", 
                NameLast = "Edwards", 
                Position = OfficerRole.Treasurer.ToString(), 
                Committee = CommitteeName.Hospitality.ToString(), 
                CommitteeName = CommitteeName.Hospitality, 
                OfficerRole = OfficerRole.Treasurer, 

            },
            new Member
            {
                NameFirst = "Beverly", 
                NameLast = "Hopkins", 
                Position = OfficerRole.Parliamentarian.ToString(), 
                OfficerRole = OfficerRole.Parliamentarian
            },

            new Member
            {
                NameFirst = "Marcus", 
                NameLast = "Dabney", 
                Committee = "Scholarship Chair", 
                CommitteeName = CommitteeName.ScholarshipChair
            },
            new Member
            {
                NameFirst = "Lashonda", 
                NameLast = "Hurst", 
                Committee = CommitteeName.Fundraising.ToString(), 
                CommitteeName = CommitteeName.Fundraising
            },
            new Member
            {
                NameFirst = "Tammy",
                NameLast = "Richardson",
                Position = "Vice President",
                OfficerRole = OfficerRole.VicePresident,
                Committee = CommitteeName.Membership.ToString(), 
                CommitteeName = CommitteeName.Membership
            },
            new Member
            {
                NameFirst = "Erakwandra",
                NameLast = "Joseph",
                Committee = "Social Committee",
                CommitteeName = CommitteeName.SocialCommittee
            }

        }.ToList();

        [HttpGet("[action]")]
        public IEnumerable<Member> Members()
        {
            return MemberData;
        }

        [HttpGet("[action]")]
        public IEnumerable<Member> Officers(int startDateIndex)
        {
            return MemberData.OrderBy(x => x.OfficerRole).Where(y => y.OfficerRole != null);
        }

        [HttpGet("[action]")]
        public IEnumerable<Member> CommitteeMembers(int startDateIndex)
        {
            return MemberData.OrderBy(c => c.CommitteeName). Where(r => r.Committee != null);
        }
    }
}
