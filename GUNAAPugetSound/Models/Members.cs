using System;
using System.Collections.Generic;
using GUNAAPugetSound.Utilities;

namespace GUNAAPugetSound.Models
{
    public class Member : Validation.IValidatable
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int GraduationYear { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }

        public string Position { get; set; }

        public string Committee { get; set; }

        Member() { }

        public Member(string namefirst, string namelast, OfficerPosition position = OfficerPosition.None, CommitteeName committee = CommitteeName.None)
        {
            NameFirst = namefirst;
            NameLast = namelast;
            Position = position.ToString();
            Committee = committee.ToString();
            Id = Randomness.Guid();
            this.EnforceValidity();
        }
    }

    public enum OfficerPosition
    {
        None,
        President,
        VicePresident,
        Secretary,
        Treasurer,
        Parliamentarian

    }

    public enum CommitteeName
    {
        None,
        ScholarshipChair,
        Fundraising,
        Membership,
        Hospitality

    }
}