using DoofenshmirtzsWebShop.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Responses
{
    public class OrderItemResponse
    {

        public int ID { get; set; }
        public int price { get; set; }
        public int quantity{ get; set; }
        public int orderID { get; set; }
        public OrderResponse order { get; set; }
        public ProductResponse Product { get; set; }
    }

}
