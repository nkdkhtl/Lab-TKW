using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    [Table("KHACH_HANG")]
    public class KhachHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string MaKhachHang { get; set; } = null!;

        [StringLength(100)]
        public string? HoTenKhachHang { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? MatKhau { get; set; }

        [StringLength(20)]
        [Phone]
        public string? DienThoai { set; get; }

        [StringLength(255)]
        public string? DiaChi { set; get; }

        // Column is DATE with default GETDATE(). Keep nullable so DB default can apply.
        [Column("NgayDangKy", TypeName = "date")]
        public DateTime? NgayDangKi { set; get; }

        // DEFAULT 1 in DB
        public bool TrangThai { get; set; } = true;
    }
}
