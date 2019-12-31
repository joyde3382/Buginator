using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("role")]
    public partial class Role
    {
        public Role(string roleName)
        {
            User = new HashSet<User>();
            RoleName = roleName;
        }

        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
