using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Requests
{
    public class LoginRequest
    {
        [Required]
        [StringLength(100, ErrorMessage = "Email must be less than 100 chars")]
        public string Username { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password must be less than 50 chars")]
        public string Password { get; set; }
    }
}
