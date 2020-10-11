namespace Entities.DTOs.Accounts
{
    public class RevokeTokenRequest : BaseModel<RevokeTokenRequest>
    {
        public string Token { get; set; }
    }
}