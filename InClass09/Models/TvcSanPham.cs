using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InClass08.Models
{
    [Table("tvcSanPham")]
    public class TvcSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required,Display(Name = "Mã sản phẩm"),StringLength(10)]
        public string tvcMaSanPham { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string tvcTenSanPham { get; set; }

        [Display(Name = "Hình Ảnh")]
        public string tvcHinhAnh { get; set; }

        [Display(Name = "Số lượng")]
        public int tvcSoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        public decimal tvcDonGia { get; set; }

        public long tvcLoaiSanPhamId { get; set; }
        [ValidateNever]
        public TvcLoaiSanPham TvcLoaiSanPham { get; set; }
    }
}
