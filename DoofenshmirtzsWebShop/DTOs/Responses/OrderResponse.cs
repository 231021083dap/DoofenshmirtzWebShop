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
    }

    public class OrderUserResponse
    {
        public int ID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string username { get; set; }
    }
}
