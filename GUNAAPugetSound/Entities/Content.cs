using GUNAAPugetSound.Entities.Enums;

namespace GUNAAPugetSound.Entities
{
    public class Content
    {
        public int Id { get; set; }

        public View View { get; set; }

        public string Header { get; set; }

        public string SubHeader { get; set; }

        public bool HasSubHeader => string.IsNullOrEmpty(SubHeader);

        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

    }

}
