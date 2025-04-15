//Cali Crouse - CSCI245 - Lab 6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliCrouse_MonsterSchoolDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MonsterSchoolDBUtil monsterSchoolDBUtil = new MonsterSchoolDBUtil();
            IEnumerable<EnrollmentsAfterOctober> enrollments = monsterSchoolDBUtil.GetEnrollmentsAfterOctober();

            foreach (EnrollmentsAfterOctober en in enrollments)
            {
                Console.WriteLine("Student Id: {0} Course Id: {1} Enrollment Date {2}", en.StudentId,
                    en.CourseId, en.EnrollDate);
            }
            Console.ReadLine();
        }
    }
}
