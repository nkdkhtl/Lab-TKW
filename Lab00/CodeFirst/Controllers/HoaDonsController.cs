using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFirst.Classes;
using CodeFirst.Models;

namespace CodeFirst.Controllers
{
    public class HoaDonsController : Controller
    {
        private readonly AppDbContext _context;

        public HoaDonsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: HoaDons
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.hoaDons.Include(h => h.KhachHang);
            return View(await appDbContext.ToListAsync());
        }

        // GET: HoaDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.hoaDons
                .Include(h => h.KhachHang)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // GET: HoaDons/Create
        public IActionResult Create()
        {
            ViewData["MaKhachHang"] = new SelectList(_context.khachHangs, "ID", "MaKhachHang");
            return View();
        }

        // POST: HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,MaHoaDon,MaKhachHang,NgayHoaDon,NgayNhan,HoTenKhachHang,Email,DienThoai,DiaChi,TongTriGia,TrangThai")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKhachHang"] = new SelectList(_context.khachHangs, "ID", "MaKhachHang", hoaDon.MaKhachHang);
            return View(hoaDon);
        }

        // GET: HoaDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.hoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }
            ViewData["MaKhachHang"] = new SelectList(_context.khachHangs, "ID", "MaKhachHang", hoaDon.MaKhachHang);
            return View(hoaDon);
        }

        // POST: HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,MaHoaDon,MaKhachHang,NgayHoaDon,NgayNhan,HoTenKhachHang,Email,DienThoai,DiaChi,TongTriGia,TrangThai")] HoaDon hoaDon)
        {
            if (id != hoaDon.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonExists(hoaDon.ID))
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
            ViewData["MaKhachHang"] = new SelectList(_context.khachHangs, "ID", "MaKhachHang", hoaDon.MaKhachHang);
            return View(hoaDon);
        }

        // GET: HoaDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.hoaDons
                .Include(h => h.KhachHang)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // POST: HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoaDon = await _context.hoaDons.FindAsync(id);
            if (hoaDon != null)
            {
                _context.hoaDons.Remove(hoaDon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonExists(int id)
        {
            return _context.hoaDons.Any(e => e.ID == id);
        }
    }
}
