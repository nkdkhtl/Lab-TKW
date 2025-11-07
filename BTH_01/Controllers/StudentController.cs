using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BTH_01.Models;

namespace BTH_01.Controllers
{
    public class StudentController : Controller
    {
        private readonly List<Student> listStudents = new();

        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student
                {
                    Id = 101,
                    Name = "Nam Khuc",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "Hanoi",
                    Email = "khucphuongnam2005@gmail.com",
                    DateOfBirth = new DateTime(2005, 3, 15)
                },
                new Student
                {
                    Id = 102,
                    Name = "Linh Tran",
                    Branch = Branch.BE,
                    Gender = Gender.Female,
                    IsRegular = false,
                    Address = "Ho Chi Minh City",
                    Email = "linh.tran@example.com",
                    DateOfBirth = new DateTime(2003, 7, 9)
                },
                new Student
                {
                    Id = 103,
                    Name = "Minh Hoang",
                    Branch = Branch.CE,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "Da Nang",
                    Email = "minh.hoang@example.com",
                    DateOfBirth = new DateTime(2004, 11, 21)
                },
                new Student
                {
                    Id = 104,
                    Name = "Thuy Nguyen",
                    Branch = Branch.EE,
                    Gender = Gender.Female,
                    IsRegular = true,
                    Address = "Can Tho",
                    Email = "thuy.nguyen@example.com",
                    DateOfBirth = new DateTime(2002, 1, 30)
                },
                new Student
                {
                    Id = 105,
                    Name = "Hieu Le",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = false,
                    Address = "Hai Phong",
                    Email = "hieu.le@example.com",
                    DateOfBirth = new DateTime(2001, 6, 5)
                }
            };
        }

        public IActionResult Index()
        {
            return View(listStudents);
        }
    }
}
