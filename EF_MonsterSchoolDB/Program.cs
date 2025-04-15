using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace EF_MonsterSchoolDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(EF_MonsterSchoolDB.MonsterSchoolModel1 db = new MonsterSchoolModel1())
            {
                // List all enrollments of students that are enrolled
                List<Enrollment> enrolledStudents = db.Enrollments.Where(e => e.IsEnrolled == true).ToList();

                foreach (Enrollment e in enrolledStudents)
                {
                    Console.WriteLine("{0} {1}", e.StudentId, e.IsEnrolled);
                }

                // List all students
                List<Student> students = db.Students.ToList();

                foreach (Student s in students)
                {
                    Console.WriteLine("{0} {1} {2} {3}", s.StudentId, s.FName, s.LName, s.Email);
                }

                // List all Instructors
                List<Instructor> instructors = db.Instructors.ToList();

                foreach (Instructor i in instructors)
                {
                    Console.WriteLine("{0} {1} {2} {3}", i.InstructorId, i.FName, i.LName, i.Email);
                }

                // Add a student
                Student studentToAdd = new Student { StudentId = 200, FName = "Bob", LName = "Bobbers", Email = "Bob@bobmail.com" };
                db.Students.Add(studentToAdd);
                db.SaveChanges();

                // Remove a student
                Student studentToDelete = db.Students.ToArray().Last();
                
                if (studentToDelete != null)
                {
                    db.Students.Remove(studentToDelete);
                    db.SaveChanges();
                }

                Console.ReadLine();
            }
        }
    }
}
