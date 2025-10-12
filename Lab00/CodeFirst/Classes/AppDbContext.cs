using Microsoft.EntityFrameworkCore;
using CodeFirst.Models;
namespace CodeFirst.Classes
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<SanPham> SanPhams { get; set; }

        public DbSet<KhachHang> khachHangs { get; set; }

        public DbSet<ChiTietHoaDon> chiTietHoaDons { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }

        public DbSet<LoaiSanPham> loaiSanPhams { get; set; }
        public DbSet<QuanTri> quanTris { get; set; }
        

    }
}
