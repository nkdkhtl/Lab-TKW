using System;
using System.ComponentModel.DataAnnotations;

namespace BTH_05.Models;

public class Enrollment
{
    [Key]
    public string EnrollmentId { get; set; }
    public string CourseId { get; set; }
    public Course Course { get; set; }
    public string LearnerId { get; set; }
    public Learner Learner { get; set; }
    public string Grade { get; set; }

}
