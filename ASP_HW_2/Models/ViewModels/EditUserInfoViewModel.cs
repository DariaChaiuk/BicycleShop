using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_HW_2.Models.ViewModels
{
    public class EditUserInfoViewModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Enter email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Choose role")]
        public string RoleName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
