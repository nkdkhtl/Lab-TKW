using Microsoft.AspNetCore.Mvc;
using Lab02.Models;
namespace Lab02.ViewComponents;

public class BookViewComponent : ViewComponent
{
    protected Book book = new Book();
    public IViewComponentResult Invoke()
    {
        var books = book.GetBookList();
        return View(books);
    }

}
