using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Accounts
{
    public class ResetPasswordRequest : BaseModel<ResetPasswordRequest>
    {
        [Required]
        public string Token { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}