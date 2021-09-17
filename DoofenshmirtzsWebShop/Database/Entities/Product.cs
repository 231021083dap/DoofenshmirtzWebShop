using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Database.Entities
{
    public class Product
    {
        [Key]
        public int productID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string productName { get; set; }

        [Required]
        public int productPrice { get; set; }

        [Required]
        public int productStock { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(3200)")]
        public string productDescription { get; set; }

        [ForeignKey("Category.categoryID")]
        public int categoryID { get; set; }
        public Category Category { get; set; }
        public List<ProductImage> ImageList { get; set; } = new();

    }
}
