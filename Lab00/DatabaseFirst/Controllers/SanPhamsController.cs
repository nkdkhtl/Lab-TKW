using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseFirst.Models;

namespace DatabaseFirst.Controllers
{
    public class SanPhamsController : Controller
    {
        private readonly QlbanHangLtwDfContext _context;
        public SanPhamsController(QlbanHangLtwDfContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            var items = _context.SanPhams.Include(s => s.MaLoaiNavigation);
            return View(await items.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.SanPhams
                .Include(s => s.MaLoaiNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            ViewData["MaLoai"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.LoaiSanPhams, "Id", "TenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSanPham,TenSanPham,HinhAnh,SoLuong,DonGia,MaLoai,TrangThai")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.LoaiSanPhams, "Id", "TenLoai", sanPham.MaLoai);
            return View(sanPham);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.SanPhams.FindAsync(id);
            if (item == null) return NotFound();
            ViewData["MaLoai"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.LoaiSanPhams, "Id", "TenLoai", item.MaLoai);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaSanPham,TenSanPham,HinhAnh,SoLuong,DonGia,MaLoai,TrangThai")] SanPham sanPham)
        {
            if (id != sanPham.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.SanPhams.Any(e => e.Id == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.LoaiSanPhams, "Id", "TenLoai", sanPham.MaLoai);
            return View(sanPham);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.SanPhams
                .Include(s => s.MaLoaiNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.SanPhams.FindAsync(id);
            if (item != null)
            {
                _context.SanPhams.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
