using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Requests
{
    public class NewOrder
    {
        [Required]
        public DateTime orderDate { get; set; }
        public int userID { get; set; }
        public List<CartItemsRequest> cartItems { get; set; }
    }
}
