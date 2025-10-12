using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models
{
    [Table("QUAN_TRI")]
    public class QuanTri
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string TaiKhoan { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string MatKhau { get; set; } = null!;

        // DEFAULT 1 in DB
        public bool TrangThai { get; set; } = true;
    }
}
