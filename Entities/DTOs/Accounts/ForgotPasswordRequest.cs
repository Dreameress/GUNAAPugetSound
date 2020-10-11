using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Accounts
{
    public class ForgotPasswordRequest : BaseModel<ForgotPasswordRequest>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}