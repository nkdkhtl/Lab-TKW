using Microsoft.AspNetCore.Mvc;
using Hello.Models;

namespace Hello.Controllers
{
    public class CategoryController : Controller
    {
        private static List<Category> categories = new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "Electronic",
                Products = new List<Product> {
                    new Product { Id = 1,Name="Laptop", Price = 3636, CategoryId = 1, CategoryName = "Electronic"},
                    new Product { Id = 2,Name="Mouse",Price=36, CategoryId = 2, CategoryName="Electronic" }
                }
            },

            new Category
            {
                Id = 2,
                Name = "Household Appliances",
                Products = new List<Product> {
                    new Product {Id= 3,Name="Cooking Pot", Price= 63, CategoryId = 3,CategoryName="Household Appliances"},
                }


            }

        };

        public IActionResult Index()
        {
            return View(categories);
        }

        public IActionResult Product(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();
            return View(category);

        }
    }
}
