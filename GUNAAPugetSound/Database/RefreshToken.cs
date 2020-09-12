using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GUNAAPugetSound.Models
{
    public class RefreshToken
    {
        [Key]
        public int RefreshTokenId { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        public string JwtId { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        public bool? Used { get; set; }
        [Required]
        public long UserId { get; set; }

        public virtual ApplicationUsersMaster User { get; set; }
    }
}
