using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    [Table("LOAI_SAN_PHAM")]
    public class LoaiSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string MaLoai { get; set; } = null!;

        [StringLength(100)]
        public string? TenLoai { get; set; }

        // DEFAULT 1 in DB
        public bool TrangThai { get; set; } = true;
    }
}
