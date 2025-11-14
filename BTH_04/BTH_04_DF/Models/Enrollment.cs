using System;
using System.Collections.Generic;

namespace BTH_04_DF.Models;

public partial class Enrollment
{
    public string EnrollmentId { get; set; } = null!;

    public string CourseId { get; set; } = null!;

    public string LearnerId { get; set; } = null!;

    public string Grade { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;

    public virtual Learner Learner { get; set; } = null!;
}
