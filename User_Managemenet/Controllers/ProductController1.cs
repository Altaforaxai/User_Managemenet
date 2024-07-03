using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using User_Managemenet.Models; // Corrected namespace here
using System.Linq;
using Microsoft.EntityFrameworkCore;
using User_Managemenet.Models;

namespace User_Managemenet.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManagementContext _context;

        public ProductController(UserManagementContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Include(p => p.ProductCategory).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ProductCategories = new SelectList(_context.ProductCategories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ProductCategories = new SelectList(_context.ProductCategories, "Id", "Name", product.ProductCategoryId);
            return View(product);
        }
    }
}
