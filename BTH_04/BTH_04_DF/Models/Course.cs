using System;
using System.Collections.Generic;

namespace BTH_04_DF.Models;

public partial class Course
{
    public string CourseId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int Credits { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
