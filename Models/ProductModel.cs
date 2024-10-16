using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NimoInfotech.Models
{
    public class ProductModel
    {
        [Key]    
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual CategoryModel Category { get; set; }
    }
}
