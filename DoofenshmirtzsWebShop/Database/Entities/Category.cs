using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Database.Entities
{
    public class Category
    {
        [Key]
        public int categoryID { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string categoryName { get; set; }
    }
}
