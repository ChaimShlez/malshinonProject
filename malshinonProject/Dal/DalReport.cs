using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Google.Protobuf.Compiler;
using malshinonProject.Entitys;
using malshinonProject.UI;
using Person = malshinonProject.Entitys.Person;

namespace malshinonProject.Dal
{
    internal class DalReport
    {

        private ConnectionWrapper _connectionWrapper;

        public DalReport(ConnectionWrapper connectionWrapper)
        {
            _connectionWrapper = connectionWrapper;
        }


        public void CreateReport(Person personRepoted, Report report, Person reporterPerson)
        {
           long reportId= svaePerson(report, reporterPerson);


            savePersonReport(reportId, personRepoted);

        }

        private void savePersonReport(long reportId, Person personRepoted)
        {
            string sql2 = @"INSERT INTO person_report (person_id ,report_id)
                                      VALUES(@person_id ,@report_id)";

            var parametersFromPersonReport = new Dictionary<string, object>
            {
                {"@person_id" ,personRepoted.Id },
                {"@report_id" ,reportId}

            };

            _connectionWrapper.ExecutAlertion(sql2, parametersFromPersonReport);
        }

        private long svaePerson(Report report, Person reporterPerson)
        {
            string sql = @"INSERT INTO report (reporter_id ,content)
                                      VALUES(@reporter_id ,@content)";

            var parameters = new Dictionary<string, object>
            {
                {"@reporter_id" ,reporterPerson.Id },
                {"@content" ,report.content}

            };

            return  _connectionWrapper.ExecutAlertion(sql, parameters);
        }
    }
}


