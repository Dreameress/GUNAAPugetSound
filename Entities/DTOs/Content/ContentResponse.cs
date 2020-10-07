using Entities.Models;

namespace Entities.DTOs.Content
{
    public class ContentResponse
    {
        public global::Entities.Models.Content Content { get; set; }

        public Officers Officers { get; set; }

        public Committee CommitteeMembers { get; set; }
    }
}
