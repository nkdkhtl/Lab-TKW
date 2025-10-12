using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseFirst.Models;

namespace DatabaseFirst.Controllers
{
    public class HoaDonsController : Controller
    {
        private readonly QlbanHangLtwDfContext _context;
        public HoaDonsController(QlbanHangLtwDfContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var items = _context.HoaDons.Include(h => h.MaKhachHangNavigation);
            return View(await items.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.HoaDons
                .Include(h => h.MaKhachHangNavigation)
                .Include(h => h.CtHoaDons)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            ViewData["MaKhachHang"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.KhachHangs, "Id", "MaKhachHang");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHoaDon,MaKhachHang,NgayHoaDon,NgayNhan,HoTenKhachHang,Email,DienThoai,DiaChi,TongTriGia,TrangThai")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhachHang"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.KhachHangs, "Id", "MaKhachHang", hoaDon.MaKhachHang);
            return View(hoaDon);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.HoaDons.FindAsync(id);
            if (item == null) return NotFound();
            ViewData["MaKhachHang"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.KhachHangs, "Id", "MaKhachHang", item.MaKhachHang);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaHoaDon,MaKhachHang,NgayHoaDon,NgayNhan,HoTenKhachHang,Email,DienThoai,DiaChi,TongTriGia,TrangThai")] HoaDon hoaDon)
        {
            if (id != hoaDon.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.HoaDons.Any(e => e.Id == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhachHang"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.KhachHangs, "Id", "MaKhachHang", hoaDon.MaKhachHang);
            return View(hoaDon);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.HoaDons
                .Include(h => h.MaKhachHangNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.HoaDons.FindAsync(id);
            if (item != null)
            {
                _context.HoaDons.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
