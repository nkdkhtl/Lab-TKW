using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KhucPhuongNam_231230845.Models;

public partial class HangHoa
{
    [BindNever]
    public int MaHang { get; set; }

    public int MaLoai { get; set; }

    public string TenHang { get; set; } = null!;

    [Range(100, 5000,ErrorMessage ="Giá nằm trong giới hạn $100 đến $5000")]
    public decimal? Gia { get; set; }

    [RegularExpression(@"^.*\.(jpg|jpeg|png|gif|tiff)$")]
    public string? Anh { get; set; }

    [BindNever]
    public virtual LoaiHang MaLoaiNavigation { get; set; } = null!;
}
