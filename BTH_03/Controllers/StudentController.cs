using BTH03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BTH03.Controllers
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
                    DateOfBirth = new DateTime(2005, 3, 15),
                    Score = 8.5
                },
                new Student
                {
                    Id = 102,
                    Name = "Linh Tran",
                    Branch = Branch.BE,
                    Gender = Gender.Female,
                    IsRegular = false,
                    Address = "Ho Chi Minh City",
                    Email = "linh.tran@gmail.com",
                    DateOfBirth = new DateTime(2003, 7, 9),
                    Score = 9.0
                },
                new Student
                {
                    Id = 103,
                    Name = "Minh Hoang",
                    Branch = Branch.CE,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "Da Nang",
                    Email = "minh.hoang@gmail.com",
                    DateOfBirth = new DateTime(2004, 11, 21),
                    Score = 7.5
                },
                new Student
                {
                    Id = 104,
                    Name = "Thuy Nguyen",
                    Branch = Branch.EE,
                    Gender = Gender.Female,
                    IsRegular = true,
                    Address = "Can Tho",
                    Email = "thuy.nguyen@gmail.com",
                    DateOfBirth = new DateTime(2002, 1, 30),
                    Score = 8.0
                },
                new Student
                {
                    Id = 105,
                    Name = "Hieu Le",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = false,
                    Address = "Hai Phong",
                    Email = "hieu.le@gmail.com",
                    DateOfBirth = new DateTime(2001, 6, 5),
                    Score = 9.5
                }
            };
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last<Student>().Id + 1;
                listStudents.Add(s);
                return View("Index", listStudents);
            }
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem {Text = "IT",Value = "1"},
                new SelectListItem {Text = "BE",Value = "2"},
                new SelectListItem {Text = "CE",Value = "3"},
                new SelectListItem {Text = "EE",Value = "4"}
            };
            return View();
        }

    }
}
