using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    [Table("CT_HOA_DON")]
    public class ChiTietHoaDon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        // FK to HOA_DON(ID), nullable in DDL
        public int? HoaDonID { get; set; }

        [ForeignKey(nameof(HoaDonID))]
        public HoaDon? HoaDon { get; set; }

        // FK to SAN_PHAM(ID), nullable in DDL
        public int? SanPhamID { get; set; }

        [ForeignKey(nameof(SanPhamID))]
        public SanPham? SanPham { get; set; }

        public int? SoLuongMua { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DonGiaMua { get; set; }

        // Computed column: ThanhTien AS (SoLuongMua * DonGiaMua) PERSISTED
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ThanhTien { get; set; }

        // DEFAULT 1 in DB
        public bool TrangThai { get; set; } = true;
    }
}
