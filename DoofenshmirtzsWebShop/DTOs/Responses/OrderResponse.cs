using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Responses
{
    public class OrderResponse
    {
        public int ID { get; set; }
        public DateTime date { get; set; }
        public OrderUserResponse User { get; set; }
        public List<OrderOrderItemResponse> OrderItems { get; set; } = new();

        
        
        

    }

    public class OrderUserResponse
    {

        public int ID { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public List<AddressResponse> address { get; set; } = new();

    }
    public class OrderOrderItemResponse
    {
        public int ID { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public int orderID { get; set; }
        public ProductResponse Product { get; set; }

    }


}
