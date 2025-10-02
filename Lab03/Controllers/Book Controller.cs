using Microsoft.AspNetCore.Mvc;
using Lab02.Models;

namespace Lab02.Controllers
{
    public class BookController : Controller
    {
        protected Book book = new Book();
        public IActionResult Index()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            var books = book.GetBookList();
            return View(books);
        }


        public PartialViewResult PopularBook()
        {
            var books = book.GetBookList();
            return PartialView(books);
        }
        public IActionResult Create()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            Book model = new Book();
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;
            Book model = book.GetBookById(id);
            return View(model);
        }
    }
}
