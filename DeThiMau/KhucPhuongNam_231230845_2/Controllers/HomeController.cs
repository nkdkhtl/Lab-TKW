using KhucPhuongNam_231230845_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace KhucPhuongNam_231230845_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger,AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //lay loai hang
        public JsonResult GetLoaiHang()
        {
            var loaiHangs = _context.LoaiHangs.ToList();
            return Json(loaiHangs);
        }

        public JsonResult GetHangByMaLoai(int? maLoai,string? keyword)
        {
            var hangHoas = _context.HangHoas.Where(x => x.Gia >= 100);
            
            if (maLoai != null)
            {
                hangHoas = hangHoas.Where(x => x.MaLoai == maLoai);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                hangHoas = hangHoas.Where(x => x.TenHang.Contains(keyword));
            }

            return Json(hangHoas.ToList());
        }
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHang,MaLoai,TenHang,Gia,Anh")] HangHoa hangHoa)
        {
            ModelState.Remove("MaLoaiNavigation");

            if (ModelState.IsValid)
            {
                _context.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai", hangHoa.MaLoai);
            return View(hangHoa);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
