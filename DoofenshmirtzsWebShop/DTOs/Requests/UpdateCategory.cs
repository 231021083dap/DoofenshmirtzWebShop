using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Requests
{
    public class UpdateCategory
    {
        [Required]
        [StringLength(50, ErrorMessage = "The categoryname must be less than 50 chars")]
        [MinLength(1, ErrorMessage = "The categoryname must be at least 1 char")]
        public string name { get; set; }
    }
}
