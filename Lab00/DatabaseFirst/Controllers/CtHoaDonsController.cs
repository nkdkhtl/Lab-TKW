using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseFirst.Models;

namespace DatabaseFirst.Controllers
{
    public class CtHoaDonsController : Controller
    {
        private readonly QlbanHangLtwDfContext _context;
        public CtHoaDonsController(QlbanHangLtwDfContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var items = _context.CtHoaDons
                .Include(c => c.HoaDon)
                .Include(c => c.SanPham);
            return View(await items.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.CtHoaDons
                .Include(c => c.HoaDon)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            ViewData["HoaDonId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.HoaDons, "Id", "MaHoaDon");
            ViewData["SanPhamId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.SanPhams, "Id", "TenSanPham");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoaDonId,SanPhamId,SoLuongMua,DonGiaMua,TrangThai")] CtHoaDon ctHoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctHoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoaDonId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.HoaDons, "Id", "MaHoaDon", ctHoaDon.HoaDonId);
            ViewData["SanPhamId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.SanPhams, "Id", "TenSanPham", ctHoaDon.SanPhamId);
            return View(ctHoaDon);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.CtHoaDons.FindAsync(id);
            if (item == null) return NotFound();
            ViewData["HoaDonId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.HoaDons, "Id", "MaHoaDon", item.HoaDonId);
            ViewData["SanPhamId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.SanPhams, "Id", "TenSanPham", item.SanPhamId);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HoaDonId,SanPhamId,SoLuongMua,DonGiaMua,TrangThai")] CtHoaDon ctHoaDon)
        {
            if (id != ctHoaDon.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctHoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.CtHoaDons.Any(e => e.Id == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoaDonId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.HoaDons, "Id", "MaHoaDon", ctHoaDon.HoaDonId);
            ViewData["SanPhamId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.SanPhams, "Id", "TenSanPham", ctHoaDon.SanPhamId);
            return View(ctHoaDon);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.CtHoaDons
                .Include(c => c.HoaDon)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.CtHoaDons.FindAsync(id);
            if (item != null)
            {
                _context.CtHoaDons.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
