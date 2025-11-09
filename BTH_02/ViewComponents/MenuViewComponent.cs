using Microsoft.AspNetCore.Mvc;
using BTH_02.Models;
using System.Collections.Generic;

namespace BTH_02.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var items = new List<MenuItem>
            {
                new MenuItem{Id=1, Name="Home", Link="/"},
                new MenuItem{Id=2, Name="About", Link="/About"},
                new MenuItem{Id=3, Name="Docs", Link="/Docs"},
                new MenuItem{Id=4, Name="Contact", Link="/Contact"},
                new MenuItem{Id=5, Name="Students", Link="/Admin/Student/Index"}
            };

            return View(items);
        }
    }
}
