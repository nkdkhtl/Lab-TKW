using Microsoft.EntityFrameworkCore;
using BTH_05.Models;

namespace BTH_05.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(serviceProvider
                .GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.Majors.Any())
                {
                    return;
                }
                var majors = new Major[]
                {
                    new Major { MajorID = "IT", MajorName = "IT" },
                    new Major { MajorID = "EC", MajorName = "Economics" },
                    new Major { MajorID = "MA", MajorName = "Mathematics" }
                };

                foreach (var major in majors)
                {
                    context.Majors.Add(major);
                }
                context.SaveChanges();

                // Seed Learners
                var learners = new Learner[]
                {
                    new Learner
                    {
                        LearnerId = "L001",
                        LastMidName = "Carson",
                        LastName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2005-09-01").ToString("yyyy-MM-dd"),
                        MajorID = "IT"
                    },
                    new Learner
                    {
                        LearnerId = "L002",
                        LastMidName = "Meredith",
                        LastName = "Alonso",
                        EnrollmentDate = DateTime.Parse("2002-09-01").ToString("yyyy-MM-dd"),
                        MajorID = "EC"
                    }
                };

                foreach (var learner in learners)
                {
                    context.Learners.Add(learner);
                }
                context.SaveChanges();

                // Seed Courses
                var courses = new Course[]
                {
                    new Course { CourseId = "1050", Title = "Chemistry", Credits = 3 },
                    new Course { CourseId = "4022", Title = "Microeconomics", Credits = 3 },
                    new Course { CourseId = "4041", Title = "Macroeconomics", Credits = 3 }
                };

                foreach (var course in courses)
                {
                    context.Courses.Add(course);
                }
                context.SaveChanges();

                var enrollments = new Enrollment[]
                {
                    new Enrollment
                    {
                        EnrollmentId = "E001",
                        LearnerId = "L001",
                        CourseId = "1050",
                        Grade = "A"
                    },
                    new Enrollment
                    {
                        EnrollmentId = "E002",
                        LearnerId = "L001",
                        CourseId = "4022",
                        Grade = "B"
                    },
                    new Enrollment
                    {
                        EnrollmentId = "E003",
                        LearnerId = "L002",
                        CourseId = "4041",
                        Grade = "A"
                    }
                };

                foreach (var enrollment in enrollments)
                {
                    context.Enrollments.Add(enrollment);
                }
                context.SaveChanges();
            }
        }
    }
}

