﻿using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}