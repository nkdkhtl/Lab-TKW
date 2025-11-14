using System.ComponentModel.DataAnnotations;

namespace BTH03.Models
{
    public class Student
    {
        [Display(Name = "Mã sinh viên")]
        public int Id { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ và tên là bắt buộc")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ và tên phải có từ 4 đến 100 ký tự")]
        public string? Name { get; set; }

        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Email là bắt buộc")]
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@gmail\.com$",
            ErrorMessage = "Email phải có đuôi @gmail.com")]
        public string? Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$",
            ErrorMessage = "Mật khẩu phải chứa ít nhất một chữ viết hoa, một chữ viết thường, một chữ số và một ký tự đặc biệt")]
        public string? Password { get; set; }

        [Display(Name = "Ngành học")]
        [Required(ErrorMessage = "Ngành học là bắt buộc")]
        public Branch? Branch { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Giới tính là bắt buộc")]
        public Gender? Gender { get; set; }

        [Display(Name = "Địa chỉ")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Địa chỉ là bắt buộc")]
        public string? Address { get; set; }

        [Display(Name = "Học chính quy")]
        public bool IsRegular { get; set; }

        [Display(Name = "Ngày sinh")]
        [Range(typeof(DateTime), "1963-01-01", "2005-12-31",
            ErrorMessage = "Ngày sinh phải từ 01/01/1963 đến 31/12/2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Điểm")]
        [Required(ErrorMessage = "Điểm là bắt buộc")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải từ 0.0 đến 10.0")]
        public double Score { get; set; }
    }
}
