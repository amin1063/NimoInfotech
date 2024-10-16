namespace NimoInfotech.Controllers
{
    using global::NimoInfotech.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;


    namespace NimoInfotech.Controllers
    {
        public class ProductController : Controller
        {
            private readonly AppDbContext _context;

           
            public ProductController(AppDbContext context) 
            {
                _context = context;
            }

            // GET: List of Products with pagination
            public ActionResult Index(int page = 1, int pageSize = 10)
            {
                var products = _context.Products.Include(p => p.Category)
                                                .OrderBy(p => p.ProductId)
                                                .Skip((page - 1) * pageSize)
                                                .Take(pageSize)
                                                .ToList();
                ViewBag.TotalRecords = _context.Products.Count();
                ViewBag.CurrentPage = page;
                ViewBag.PageSize = pageSize;

                return View(products);
            }




            // GET: Create Product
            public ActionResult Create()
            {
                ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "CategoryName");
                return View();
            }



            // POST: Create Product

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(ProductCreateViewModel productViewModel)
            {
                if (ModelState.IsValid)
                {
                    var product = new ProductModel
                    {
                        ProductName = productViewModel.ProductName,
                        CategoryId = productViewModel.CategoryId
                    };

                    // Save the product
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
     
                ViewBag.CategoryId = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
                return View(productViewModel);
            }


            // GET: Edit Product
            public ActionResult Edit(int id)
            {
                var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    return NotFound(); 
                }
                var productViewModel = new ProductCreateViewModel
                {
                    ProductId = product.ProductId, 
                    ProductName = product.ProductName,
                    CategoryId = product.CategoryId
                };

                ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
                return View(productViewModel); 
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
                    product.ProductName = productViewModel.ProductName;
                    product.CategoryId = productViewModel.CategoryId;
                    _context.SaveChanges(); 
                    return RedirectToAction("Index");
                }
                ViewBag.CategoryId = new SelectList(_context.Categories, "CategoryId", "CategoryName", productViewModel.CategoryId);
                return View(productViewModel);
            }



            // GET: Delete Product
            public ActionResult Delete(int id)
            {
                var product = _context.Products.Include(p => p.Category).FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    return NotFound(); 
                }

                return View(product);
            }

            // POST: Delete Product
            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }
                _context.Products.Remove(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }

}
 