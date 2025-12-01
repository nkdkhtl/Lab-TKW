using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KhucPhuongNam_231230845_2.Models;

public partial class HangHoa
{
    [BindNever]
    public int MaHang { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn loại hàng")]
    [Display(Name = "Loại hàng")]
    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên hàng hóa")]
    [StringLength(100, ErrorMessage = "Tên hàng không quá 100 ký tự")]
    [Display(Name = "Tên hàng hóa")]
    public string TenHang { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập giá")]
    [Range(0.01, 999999999, ErrorMessage = "Giá phải lớn hơn 0")]
    [Display(Name = "Giá")]
    public decimal? Gia { get; set; }

    [Display(Name = "Ảnh")]
    [RegularExpression(@".*\.(jpg|jpeg|png|gif|JPG|JPEG|PNG|GIF)$", ErrorMessage = "Ảnh phải có định dạng jpg, jpeg, png hoặc gif")]
    public string? Anh { get; set; }

    [BindNever]
    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
