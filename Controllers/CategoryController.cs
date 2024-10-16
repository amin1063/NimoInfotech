using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NimoInfotech.Models;

namespace NimoInfotech.Controllers
{
    public class CategoryController : Controller
    {
        // Use dependency injection to get the DbContext
        private readonly AppDbContext _context;

       
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: List of Categories
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // GET: Create Category
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create Category
       
        [HttpPost]
        public ActionResult Create(CategoryModel category)
        {
            Console.WriteLine("Create action hit."); 

            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            return View(category);
        }

        // GET: Edit Category
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound(); 
            }
            return View(category);
        }

        // POST: Edit Product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCreateViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = _context.Products.Find(productViewModel.ProductId); 

                if (product == null)
                {
                    return NotFound(); 
                }

                // Update properties
                product.ProductName = productViewModel.ProductName;
                product.CategoryId = productViewModel.CategoryId;

                _context.SaveChanges(); // Save changes
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "CategoryName", productViewModel.CategoryId);
            return View(productViewModel);
        }

        // GET: Delete Category
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound(); 
            }
            return View(category);
        }

        // POST: Delete Category
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound(); 
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
