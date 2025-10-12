using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    [Table("HOA_DON")]
    public class HoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string MaHoaDon { get; set; } = null!;

        // FK to KHACH_HANG(ID), nullable in DDL
        public int? MaKhachHang { get; set; }

        [ForeignKey(nameof(MaKhachHang))]
        public KhachHang? KhachHang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHoaDon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhan { get; set; }

        [StringLength(100)]
        public string? HoTenKhachHang { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(20)]
        [Phone]
        public string? DienThoai { get; set; }

        [StringLength(255)]
        public string? DiaChi { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TongTriGia { get; set; }

        // DEFAULT 1 in DB
        public bool TrangThai { get; set; } = true; 
    }
}
