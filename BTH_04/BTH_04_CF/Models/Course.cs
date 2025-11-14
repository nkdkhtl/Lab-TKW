using System;
using System.ComponentModel.DataAnnotations;

namespace BTH_04.Models;

public class Course
{
    [Key]
    public string CourseId { get; set; }

    public string Title { get; set; }

    public int Credits { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
