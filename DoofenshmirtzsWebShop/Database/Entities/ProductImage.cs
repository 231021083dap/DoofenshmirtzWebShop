using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoofenshmirtzsWebShop.Database.Entities
{
    public class ProductImage
    {
        [Key]
        public int productImageID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        public string productImageImage { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string productImageImageDescription { get; set; }

        [ForeignKey("Product.productID")]
        public int productID { get; set; }

        public Product product { get; set; }
    }
}
