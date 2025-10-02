
using Microsoft.AspNetCore.Mvc;
using Hello.Models;
namespace Hello.Controllers;

public class ProductController : Controller
{
    private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price=3636},
        new Product { Id = 2, Name = "Mouse", Price=36 }
    };
    
    public IActionResult Index()
    {
        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();
        return View(products);
    }

}
