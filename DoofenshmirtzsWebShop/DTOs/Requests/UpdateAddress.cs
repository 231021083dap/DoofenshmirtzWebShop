using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Requests
{
    public class UpdateAddress
    {
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string addressCustomerName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string addressStreetName { get; set; }

        [Required]
        public int addressPostalCode { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50")]
        public string addressCountryName { get; set; }

        public int userID { get; set; }
    }
}
