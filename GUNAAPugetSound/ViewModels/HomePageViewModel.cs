using System.Collections.Generic;
using GUNAAPugetSound.Models;

namespace GUNAAPugetSound.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Member> Members { get; set; }
        public string CurrentGreeting { get; set; }

      
    }
}
