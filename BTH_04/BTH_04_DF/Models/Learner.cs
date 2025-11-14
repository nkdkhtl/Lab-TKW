using System;
using System.Collections.Generic;

namespace BTH_04_DF.Models;

public partial class Learner
{
    public string LearnerId { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string LastMidName { get; set; } = null!;

    public string EnrollmentDate { get; set; } = null!;

    public string MajorId { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Major Major { get; set; } = null!;
}
