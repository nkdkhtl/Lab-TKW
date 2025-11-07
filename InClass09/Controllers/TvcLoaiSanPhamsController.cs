using InClass08.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InClass08.Controllers
{
    public class TvcLoaiSanPhamsController : Controller
    {
        private readonly tvcInClass09LabCFContext _context;

        public TvcLoaiSanPhamsController(tvcInClass09LabCFContext context)
        {
            _context = context;
        }

        // GET: TvcLoaiSanPhams
        public async Task<IActionResult> Index()
        {
            return View(await _context.tvcLoaiSanPhams.ToListAsync());
        }

        // GET: TvcLoaiSanPhams/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcLoaiSanPham = await _context.tvcLoaiSanPhams
                .FirstOrDefaultAsync(m => m.tvcId == id);
            if (tvcLoaiSanPham == null)
            {
                return NotFound();
            }

            return View(tvcLoaiSanPham);
        }

        // GET: TvcLoaiSanPhams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TvcLoaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tvcId,tvcMaLoai,tvcTenLoai,tvcTrangThai")] TvcLoaiSanPham tvcLoaiSanPham)
        {
            ModelState.Remove(nameof(TvcLoaiSanPham.TvcSanPham));
            if (ModelState.IsValid)
            {
                _context.Add(tvcLoaiSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tvcLoaiSanPham);
        }

        // GET: TvcLoaiSanPhams/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcLoaiSanPham = await _context.tvcLoaiSanPhams.FindAsync(id);
            if (tvcLoaiSanPham == null)
            {
                return NotFound();
            }
            return View(tvcLoaiSanPham);
        }

        // POST: TvcLoaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("tvcId,tvcMaLoai,tvcTenLoai,tvcTrangThai")] TvcLoaiSanPham tvcLoaiSanPham)
        {
            ModelState.Remove(nameof(TvcLoaiSanPham.TvcSanPham));

            if (id != tvcLoaiSanPham.tvcId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvcLoaiSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvcLoaiSanPhamExists(tvcLoaiSanPham.tvcId))
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
            return View(tvcLoaiSanPham);
        }

        // GET: TvcLoaiSanPhams/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvcLoaiSanPham = await _context.tvcLoaiSanPhams
                .FirstOrDefaultAsync(m => m.tvcId == id);
            if (tvcLoaiSanPham == null)
            {
                return NotFound();
            }

            return View(tvcLoaiSanPham);
        }

        // POST: TvcLoaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tvcLoaiSanPham = await _context.tvcLoaiSanPhams.FindAsync(id);
            if (tvcLoaiSanPham != null)
            {
                _context.tvcLoaiSanPhams.Remove(tvcLoaiSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvcLoaiSanPhamExists(long id)
        {
            return _context.tvcLoaiSanPhams.Any(e => e.tvcId == id);
        }
    }
}
