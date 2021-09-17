using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Responses
{
    public class ProductImageResponse
    {
        public int ID { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public ProductImageProductResponse FK_Product { get; set; }
    }

    public class ProductImageProductResponse
    {
        // Product iamge to product response
        public int ID { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int stock { get; set; }
        public string description { get; set; }
    }
}
