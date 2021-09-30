using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Requests
{
    public class UpdateProduct
    {
        [Required]
        [StringLength(100, ErrorMessage = "Productname has to be less than 100 chars")]
        [MinLength(1, ErrorMessage = "Productname must contain at least 1 char")]
        public string name { get; set; }

        [Required]
        public int price { get; set; }

        [Required]
        public int stock { get; set; }

        [Required]
        [StringLength(3200, ErrorMessage = "Too long bruh - just too long!")]   
        [MinLength(1, ErrorMessage = "At least add a dot")]
        public string description { get; set; }

        [Required]
        public int categoryId { get; set; }
    }
}
