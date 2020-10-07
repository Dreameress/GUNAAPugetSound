using System;

namespace Entities.Models
{
    public class Member
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
    }
}