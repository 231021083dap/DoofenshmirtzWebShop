using DoofenshmirtzsWebShop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Responses
{
    public class UserResponse
    {
        public int ID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public Role Role { get; set; }
    }
}
