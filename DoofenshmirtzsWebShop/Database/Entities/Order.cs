using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Database.Entities
{
    public class Order
    {
        [Key]
        public int orderID { get; set; }

        [Required]
        public DateTime orderDate { get; set; }

        [ForeignKey("User.userID")]
        public int userID { get; set; }

        public User User { get; set; }
        public List<OrderItem> orderItems { get; set; }
    }
}
