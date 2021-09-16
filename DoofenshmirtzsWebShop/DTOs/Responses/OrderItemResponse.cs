using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Responses
{
    public class OrderItemResponse
    {
        public int ID { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
    }

    public class OrderItemOrderResponse
    {
        // OrderItem to order response

        public int ID { get; set; }
        public DateTime date { get; set; }
    }

    public class OrderItemProductResponse
    {
        // Orderitem to Product response

        public int ID { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public string description { get; set; }
    }
}
