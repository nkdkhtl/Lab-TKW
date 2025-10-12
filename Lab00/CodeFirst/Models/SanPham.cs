using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    [Table("SAN_PHAM")]
    public class SanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Required]
        [StringLength(20)]
        public string MaSanPham { get; set; } = null!;

        [StringLength(100)]
        public string? TenSanPham { get; set; }

        [StringLength(255)]
        public string? HinhAnh { get; set; }

        // Nullable because the DB column does not declare NOT NULL
        public int? SoLuong { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DonGia { get; set; }

        // FK to LOAI_SAN_PHAM(ID), nullable (no NOT NULL in DDL)
        public int? MaLoai { get; set; }

        [ForeignKey(nameof(MaLoai))]
        public LoaiSanPham? LoaiSanPham { get; set; }

        // DEFAULT 1 in DB
        public bool TrangThai { get; set; } = true;
    }
}
