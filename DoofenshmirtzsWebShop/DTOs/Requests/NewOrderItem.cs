using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Requests
{
    public class NewOrderItem
    {
        [Required]
        public int orderItemQuantity { get; set; }

        [Required]
        public int orderItemPrice { get; set; }
        [ForeignKey("Order.orderID")]
        public int orderID { get; set; }
        [ForeignKey("Product.productID")]
        public int productID { get; set; }
    }
}
