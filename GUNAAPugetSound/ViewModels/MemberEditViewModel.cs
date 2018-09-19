using System.ComponentModel.DataAnnotations;
using GUNAAPugetSound.Models;

namespace GUNAAPugetSound.ViewModels
{
    public class MemberEditViewModel
    {
        [Required, MaxLength(80) ]
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public OfficerPosition Position { get; set; }
    }
}
