using System.ComponentModel.DataAnnotations;
using GUNAAPugetSound.Entities.Enums;
using GUNAAPugetSound.Models;

namespace GUNAAPugetSound.ViewModels
{
    public class MemberEditViewModel
    {
        [Required, MaxLength(80) ]
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public OfficerRole Position { get; set; }
    }
}
