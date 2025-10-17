using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InClass08.Models;

namespace InClass08.Controllers
{
    public class TvcSanPhamsController : Controller
    {
        private readonly tvcInClass09LabCFContext _context;

        public TvcSanPhamsController(tvcInClass09LabCFContext context)
        {
            _context = context;
        }

        // GET: TvcSanPhams
        public async Task<IActionResult> Index()
        {
            var tvcInClass09LabCFContext = _context.tvcSanPhams.Include(t => t.TvcLoaiSanPham);
            return View(await tvcInClass09LabCFContext.ToListAsync());
        }

        // GET: TvcSanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcSanPham = await _context.tvcSanPhams
                .Include(t => t.TvcLoaiSanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tvcSanPham == null)
            {
                return NotFound();
            }

            return View(tvcSanPham);
        }

        // GET: TvcSanPhams/Create
        public IActionResult Create()
        {
            ViewData["tvcLoaiSanPhamId"] = new SelectList(_context.tvcLoaiSanPhams, "tvcId", "tvcId");
            return View();
        }

        // POST: TvcSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tvcMaSanPham,tvcTenSanPham,tvcHinhAnh,tvcSoLuong,tvcDonGia,tvcLoaiSanPhamId")] TvcSanPham tvcSanPham)
        {
            ModelState.Remove(nameof(TvcSanPham.TvcLoaiSanPham));
            
            if (ModelState.IsValid)
            {
                _context.Add(tvcSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["tvcLoaiSanPhamId"] = new SelectList(_context.tvcLoaiSanPhams, "tvcId", "tvcTenLoai", tvcSanPham.tvcLoaiSanPhamId);
            return View(tvcSanPham);
        }

        // GET: TvcSanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcSanPham = await _context.tvcSanPhams.FindAsync(id);
            if (tvcSanPham == null)
            {
                return NotFound();
            }
            ViewData["tvcLoaiSanPhamId"] = new SelectList(_context.tvcLoaiSanPhams, "tvcId", "tvcTenLoai", tvcSanPham.tvcLoaiSanPhamId);
            return View(tvcSanPham);
        }

        // POST: TvcSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,tvcMaSanPham,tvcTenSanPham,tvcHinhAnh,tvcSoLuong,tvcDonGia,tvcLoaiSanPhamId")] TvcSanPham tvcSanPham)
        {
            ModelState.Remove(nameof(TvcSanPham.TvcLoaiSanPham));
            if (id != tvcSanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvcSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvcSanPhamExists(tvcSanPham.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["tvcLoaiSanPhamId"] = new SelectList(_context.tvcLoaiSanPhams, "tvcId", "tvcTenLoai", tvcSanPham.tvcLoaiSanPhamId);
            return View(tvcSanPham);
        }

        // GET: TvcSanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcSanPham = await _context.tvcSanPhams
                .Include(t => t.TvcLoaiSanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tvcSanPham == null)
            {
                return NotFound();
            }

            return View(tvcSanPham);
        }

        // POST: TvcSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tvcSanPham = await _context.tvcSanPhams.FindAsync(id);
            if (tvcSanPham != null)
            {
                _context.tvcSanPhams.Remove(tvcSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvcSanPhamExists(int id)
        {
            return _context.tvcSanPhams.Any(e => e.Id == id);
        }
    }
}
