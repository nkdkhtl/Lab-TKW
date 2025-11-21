using System;
using System.ComponentModel.DataAnnotations;
namespace BTH_06.Models;

public class Major
{
    [Key]
    public string MajorID { get; set; }

    public string MajorName { get; set; }

    public ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
