using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using GUNAAPugetSound.Entities;

namespace GUNAAPugetSound.Models.Content
{
    public class ContentResponse
    {
        public global::Entities.Models.Content Content { get; set; }

        public Officers Officers { get; set; }

        public Committee CommitteeMembers { get; set; }
    }
}
