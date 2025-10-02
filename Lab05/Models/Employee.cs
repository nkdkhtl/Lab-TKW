using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Lab05.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string fullName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Precision(18, 3)]
        public decimal Salary { get; set; }

        public string Status { get; set; }

    }
}
