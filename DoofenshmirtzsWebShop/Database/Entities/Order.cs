using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        // Add foreign key to UserId
    }
}
