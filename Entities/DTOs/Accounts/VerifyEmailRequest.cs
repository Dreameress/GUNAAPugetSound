using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Accounts
{
    public class VerifyEmailRequest : BaseModel<VerifyEmailRequest>
    {
        [Required]
        public string Token { get; set; }
    }
}