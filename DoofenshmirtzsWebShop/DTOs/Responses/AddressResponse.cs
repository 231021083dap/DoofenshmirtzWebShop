using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Responses
{
    public class AddressResponse
    {
        public int ID { get; set; }
        public string customerName { get; set; }
        public string streetName { get; set; }
        public int postalCode { get; set; }
        public string countryName { get; set; }
        public AddressUserResponse user { get; set; }
    }

    public class AddressUserResponse
    {
        public int ID { get; set; }
        public string email { get; set; }
        public string username { get; set; }
    }
}
