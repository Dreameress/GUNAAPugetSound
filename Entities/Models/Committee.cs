using GUNAAPugetSound.Entities.Enums;

namespace Entities.Models
{
    public class Committee
    {
        public int Id { get; set; }

        public CommitteeName Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}