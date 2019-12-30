using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("user")]
    public class User
    {
        public Guid UserId{ get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [StringLength(4, ErrorMessage = "Age can't be longer than 4 characters")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(60, ErrorMessage = "Email can't be longer than 60 characters")]
        public string Email { get; set; }
        public string Note { get; set; }
        public DateTime DateOfCreation { get; set; }



        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }

        public virtual ICollection<User_has_ticket> User_has_tickets { get; set; }
        public virtual ICollection<User_has_project> User_has_projects { get; set; }

    }
}
