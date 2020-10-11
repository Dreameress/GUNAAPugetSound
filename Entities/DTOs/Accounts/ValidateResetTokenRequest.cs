using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Accounts
{
    public class ValidateResetTokenRequest : BaseModel<ValidateResetTokenRequest>
    {
        [Required]
        public string Token { get; set; }
    }
}