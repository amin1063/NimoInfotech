using System.ComponentModel.DataAnnotations;

namespace NimoInfotech.Models
{
    public class CategoryModel
    {

        public CategoryModel()
        {
            Products = new HashSet<ProductModel>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        public string CategoryName { get; set; }
        public virtual ICollection<ProductModel> Products { get; set; }
    }
}
