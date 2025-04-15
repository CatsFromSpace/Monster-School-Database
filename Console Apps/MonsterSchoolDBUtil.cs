//Cali Crouse - CSCI245 - Lab 6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace CaliCrouse_MonsterSchoolDB
{
    public class MonsterSchoolDBUtil
    {
        // Create and initialize database connections via constructor
        DatabaseProviderFactory factory;
        SqlDatabase sqlDB;

        public MonsterSchoolDBUtil()
        {
            factory = new DatabaseProviderFactory();
            sqlDB = (SqlDatabase)factory.CreateDefault();
        }

        public IEnumerable<EnrollmentsAfterOctober> GetEnrollmentsAfterOctober()
        {
            List<EnrollmentsAfterOctober> enrollments = new List<EnrollmentsAfterOctober>();

            using (DbCommand sprocCmd = sqlDB.GetStoredProcCommand("EnrollmentsAfterOctober"))
            {
                using (IDataReader sprocReader = sqlDB.ExecuteReader(sprocCmd)) 
                {
                    while (sprocReader.Read())
                    {
                        EnrollmentsAfterOctober en = new EnrollmentsAfterOctober();

                        try
                        {
                            en.StudentId = sprocReader.GetInt32(0);
                            en.CourseId = sprocReader.GetInt32(1);
                            en.EnrollDate = sprocReader.GetString(2);

                            enrollments.Add(en);
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine("Exception " + ex.Message);
                        }
                    }
                }
            }

            return enrollments;
        }
    }
}
