using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuginatorBackend.Models
{
    public enum Role { Admin, Developer, Tester };
    public class User
    {
        public Guid UserId{ get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [StringLength(4, ErrorMessage = "Age can't be longer than 4 characters")]
        public int age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(60, ErrorMessage = "Email can't be longer than 60 characters")]
        public string email { get; set; }
        public string note { get; set; }
        public DateTime createdDate { get; set; }
        public Role role { get; set; }


        public virtual ICollection<TicketRole> ticketRoles { get; set; }
        public virtual ICollection<UserToProject> userToProjects { get; set; }

    }
}
