using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Requests
{
    public class UpdateUser
    {
        [Required]
        [Column(TypeName = "nvarchar(320)")]
        public string userEmail { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string userPassword { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string userName { get; set; }

        public Helpers.Role userRole { get; set; }
    }
}
