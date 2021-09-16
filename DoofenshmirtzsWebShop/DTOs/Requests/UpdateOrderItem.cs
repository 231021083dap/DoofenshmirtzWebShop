using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Requests
{
    public class UpdateOrderItem
    {
        [Required]
        public int orderItemQuantity { get; set; }

        [Required]
        public int orderItemPrice { get; set; }

        public int orderID { get; set; }

        public int productID { get; set; }
    }    
}
