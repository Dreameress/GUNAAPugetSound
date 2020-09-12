

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GUNAAPugetSound.Models
{
    public class ApplicationUserRoles
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public long RoleId { get; set; }
        [ForeignKey("RoleId"), Required]
        public virtual ApplicationRolesMaster Role { get; set; }
        [ForeignKey("UserId"), Required]
        public virtual ApplicationUsersMaster User { get; set; }
    }
}
