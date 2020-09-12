using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GUNAAPugetSound.Models
{
    public class ApplicationRolesMaster
    {
        public ApplicationRolesMaster()
        {
            UserRoles = new HashSet<ApplicationUserRoles>();
        }

        public long RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime UpdatedOn { get; set; }

        public virtual ICollection<ApplicationUserRoles> UserRoles { get; set; }

    }
}
