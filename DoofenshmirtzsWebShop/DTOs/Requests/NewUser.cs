using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace DoofenshmirtzsWebShop.DTOs.Requests
{
    public class NewUser
    {
        [Required]
        [StringLength(320, ErrorMessage = "Email has to be less than 320 chars")]
        [MinLength(1, ErrorMessage = "Email must contain at least 1 char")]
        public string email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Username has to be less than 320 chars")]
        [MinLength(1, ErrorMessage = "Username must contain at least 1 char")]
        public string username { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Email has to be less than 320 chars")]
        [MinLength(1, ErrorMessage = "Email must contain at least 1 char")]
        public string password { get; set; }


        public Helpers.Role role { get; set; }
    }
}
