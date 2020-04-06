using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSD.Entities.Shared
{
    public class UserApp : IdentityUser
    {
        public UserApp()
        {

        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Fullname
        {
            get { return $"{Firstname} {Lastname}"; }
        }
        public int ? PersonelId { get; set; }
        public bool Status { get; set; }

        [ForeignKey("PersonelId")]
        public virtual Personel Personel { get; set; }

    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base()
        {
        }

        public ApplicationRole(string roleName)
        {
            Name = roleName;
        }
        public string Description { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        
    }

    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public virtual UserApp User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }

}
