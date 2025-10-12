using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseFirst.Models;

namespace DatabaseFirst.Controllers
{
    public class QuanTrisController : Controller
    {
        private readonly QlbanHangLtwDfContext _context;
        public QuanTrisController(QlbanHangLtwDfContext context) => _context = context;

        public async Task<IActionResult> Index()
        {
            return View(await _context.QuanTris.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.QuanTris.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaiKhoan,MatKhau,TrangThai")] QuanTri quanTri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanTri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanTri);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.QuanTris.FindAsync(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaiKhoan,MatKhau,TrangThai")] QuanTri quanTri)
        {
            if (id != quanTri.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanTri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.QuanTris.Any(e => e.Id == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(quanTri);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var item = await _context.QuanTris.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.QuanTris.FindAsync(id);
            if (item != null)
            {
                _context.QuanTris.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
