using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Requests
{
    public class RegisterUser
    {
        [Required]
        [StringLength(320, ErrorMessage = "Email must be less than 128 chars")]
        public string mmail { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password must be less than 32 chars")]
        public string password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Username must be less than 32 chars")]
        public string username { get; set; }
    }
}
