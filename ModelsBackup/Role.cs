using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Role
    {
        public Guid RoleId { get; set; }

        [Required(ErrorMessage = "RoleName is required")]
        [StringLength(60, ErrorMessage = "RoleName can't be longer than 60 characters")]
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
