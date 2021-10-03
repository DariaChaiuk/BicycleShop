using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_2.Models.ViewModels
{
    public class EditUsersViewModel
    {
       public IEnumerable<UserRole> Users { get; set; }
       public IEnumerable<IdentityRole> Roles { get; set; }
    }

    public class UserRole
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }
}
