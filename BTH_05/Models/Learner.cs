using System;
using System.ComponentModel.DataAnnotations;

namespace BTH_05.Models;

public class Learner
{
    [Key]
    [Required(ErrorMessage = "Mã học viên không được để trống")]
    public string LearnerId { get; set; }


    public string LastName { get; set; }
    public string LastMidName { get; set; }
    public string EnrollmentDate { get; set; }
    
    [Required(ErrorMessage = "Vui lòng chọn ngành")]
    public string MajorID { get; set; }
    public Major Major { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();


}
