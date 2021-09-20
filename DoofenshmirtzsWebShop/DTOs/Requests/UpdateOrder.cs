using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.DTOs.Requests
{
    public class UpdateOrder
    {
        [Required]
        public DateTime orderDate { get; set; }

        [ForeignKey("User.userID")]
        public int userID { get; set; }
        public int orderItemId { get; set; }
    }
}
