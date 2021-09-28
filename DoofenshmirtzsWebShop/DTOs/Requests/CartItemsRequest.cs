using DoofenshmirtzsWebShop.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Requests
{
    public class CartItemsRequest
    {
        public int price { get; set; }
        public int amount { get; set; }
        public int ProductID { get; set; }
        public string productName { get; set; }
    }
}
