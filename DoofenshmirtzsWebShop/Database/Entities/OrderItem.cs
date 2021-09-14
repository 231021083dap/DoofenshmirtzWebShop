using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Database.Entities
{
    public class OrderItem
    {
        [Key]
        public int orderItemID { get; set; }

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
