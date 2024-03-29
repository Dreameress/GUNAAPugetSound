﻿using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Accounts
{
    public class AuthenticateRequest : BaseModel<AuthenticateRequest>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
