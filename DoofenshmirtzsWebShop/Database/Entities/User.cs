using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Database.Entities
{
    public class User
    {
        [Key]
        public int userID { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(320")]
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
