using Microsoft.EntityFrameworkCore;
namespace InClass08.Models
{
    public class tvcInClass09LabCFContext:DbContext
    {
        public tvcInClass09LabCFContext(DbContextOptions<tvcInClass09LabCFContext> options) : base(options)
        {

        }
        
        public DbSet<TvcLoaiSanPham> tvcLoaiSanPhams { get; set; }
        public DbSet<TvcSanPham> tvcSanPhams { get; set; }
    }
}
