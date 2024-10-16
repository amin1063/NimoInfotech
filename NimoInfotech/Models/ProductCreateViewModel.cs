using System.ComponentModel.DataAnnotations;

namespace NimoInfotech.Models
{
    public class ProductCreateViewModel
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is required.")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
    }

}
