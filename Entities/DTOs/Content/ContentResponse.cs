using System.Collections.Generic;
using Entities.Models;

namespace Entities.DTOs.Content
{
    public class ContentResponse
    {
        public Models.Content Content { get; set; }
        public IEnumerable<Officer> Officers { get; set; }
        public IEnumerable<CommitteeMember> CommitteeMembers { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Album> Albums { get; set; }
    }
}
