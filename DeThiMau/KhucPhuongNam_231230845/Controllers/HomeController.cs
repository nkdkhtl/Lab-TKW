using System.Diagnostics;
using KhucPhuongNam_231230845.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KhucPhuongNam_231230845.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var loaiHangs = _context.LoaiHangs.ToList();
            ViewBag.LoaiHangs = loaiHangs;

            var hangHoas = _context.HangHoas.Where(h => h.Gia >= 100).ToList();
            ViewBag.HangHoas = hangHoas;
            return View(loaiHangs);
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.LoaiHangs = _context.LoaiHangs.ToList();
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa model)
        {
            ModelState.Remove("MaLoaiNavigation");
            ModelState.Remove("MaHang");
            if (!ModelState.IsValid)
            {
                ViewBag.LoaiHangs = _context.LoaiHangs.ToList();
                ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
                return View(model);
            }

            try
            {
                _context.HangHoas.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Có lỗi: " + ex.Message;
                ViewBag.LoaiHangs = _context.LoaiHangs.ToList();
                ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult GetLoaiHangByMaHang(int maLoai)
        {
            try
            {
                var hangHoas = _context.HangHoas.Where(h => h.MaLoai == maLoai)
                    .Select(h => new
                    {
                        h.MaHang,
                        h.TenHang,
                        h.Gia,
                        h.Anh
                    })
                    .ToList();
                return Json(hangHoas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi server: " + ex.Message);
                throw;
            }
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
