using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseFirst.Models;

namespace DatabaseFirst.Controllers
{
    public class LoaiSanPhamsController : Controller
    {
        private readonly QlbanHangLtwDfContext _context;
        public LoaiSanPhamsController(QlbanHangLtwDfContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiSanPhams.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.LoaiSanPhams
                .Include(l => l.SanPhams)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,TenLoai,TrangThai")] LoaiSanPham loaiSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiSanPham);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.LoaiSanPhams.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaLoai,TenLoai,TrangThai")] LoaiSanPham loaiSanPham)
        {
            if (id != loaiSanPham.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.LoaiSanPhams.Any(e => e.Id == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(loaiSanPham);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.LoaiSanPhams.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.LoaiSanPhams.FindAsync(id);
            if (item != null)
            {
                _context.LoaiSanPhams.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
