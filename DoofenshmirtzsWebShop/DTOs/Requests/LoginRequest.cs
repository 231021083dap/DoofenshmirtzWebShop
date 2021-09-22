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
        [StringLength(320, ErrorMessage = "Email must be less than 320 chars")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Password must be less than 50 chars")]
        public string Password { get; set; }
    }
}
