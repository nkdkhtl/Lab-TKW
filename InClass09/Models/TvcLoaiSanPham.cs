using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InClass08.Models
{
    [Table("tvcLoaiSanPham")]
    [Index(nameof(tvcMaLoai),IsUnique = true)]
    [ValidateNever]

    public class TvcLoaiSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long tvcId { get; set; }
        
        [Display(Name = "Mã loại"),
        StringLength(20)]
        public string tvcMaLoai { get; set; }

        [Display(Name = "Tên loại"),
            StringLength(50)]
        public string tvcTenLoai { get; set; }

        [Display(Name = "Trạng thái")]
        public bool tvcTrangThai { get; set; }

        [ValidateNever]
        public ICollection<TvcSanPham> TvcSanPham { get; set; }
    }
}
