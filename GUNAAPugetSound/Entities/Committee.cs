using GUNAAPugetSound.Entities.Enums;

namespace GUNAAPugetSound.Entities
{
    public class Committee
    {
        public int Id { get; set; }

        public CommitteeName Name { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}