using System;
using System.Collections.Generic;

namespace BTH_04_DF.Models;

public partial class Major
{
    public string MajorId { get; set; } = null!;

    public string MajorName { get; set; } = null!;

    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
