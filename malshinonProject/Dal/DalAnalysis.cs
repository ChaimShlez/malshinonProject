using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bogus;
using malshinonProject.Entitys;
using malshinonProject.UI;
using MySqlX.XDevAPI.Common;
using static Mysqlx.Error.Types;

namespace malshinonProject.Dal
{
    internal class DalAnalysis
    {
        private ConnectionWrapper _connectionWrapper;

        public DalAnalysis(ConnectionWrapper connectionWrapper)
        {
            _connectionWrapper = connectionWrapper;
        }
        public Alert CreateAlertFromDangerousPerson()
        {
            Alert alert = null;
            string sql = @"SELECT person_report.person_id, COUNT(*) AS report_count 
                FROM person_report
                GROUP BY person_id
                HAVING report_count > 3";

            var reader = _connectionWrapper.ExecuteSelect(sql);

            if (reader != null)
            {
                while (reader.Read())
                {
                    alert = new Alert
                    {
                       
               
                        person_id = reader.GetInt32("person_id"),
                        severity= Enum.EnumSeverity.high

                    };

                }
                return alert;
            }
            else
            {
                return null;
            }
        }

        public Alert CreateAlertFromDangerousReport()
        {
            Alert alert = null;
            string sql = @"SELECT person_report.report_id, COUNT(*) AS report_count 
                FROM person_report
                GROUP BY report_id
                HAVING report_count > 3";

            var reader = _connectionWrapper.ExecuteSelect(sql);

            if (reader != null)
            {
                while (reader.Read())
                {
                    alert = new Alert
                    {


                        report_id = reader.GetInt32("reprot_id"),
                        severity = Enum.EnumSeverity.high

                    };

                }
                return alert;
            }
            else
            {
                return null;
            }
        }

        public Alert CreateAlertFromDangerousCity()
        {
            Alert alert = null;
            string sql = @"SELECT report.city, COUNT(*) AS report_count 
                           FROM report
                           WHERE report_time >= NOW() - INTERVAL 1 DAY
                           GROUP BY report.city
                           HAVING report_count > 3";
            var reader = _connectionWrapper.ExecuteSelect(sql);

            if (reader != null)
            {
                while (reader.Read())
                {
                    alert = new Alert
                    {
              
                        severity = Enum.EnumSeverity.critical,
                        city = reader.GetString("city")
                      
                    };

                }
                return alert;
            }
            else
            {
                return null;
            }

            
        }

        public void saveAlert(Alert alert)
        {
            string sql = @"INSERT INTO alert (report_id,severity, message,person_id)
                             VALUES(@report_id,@severity,@message,@person_id)";

            var parametrs = new Dictionary<string, object>
            {
                    {"@report_id",alert.report_id },
                    {"@severity",alert.severity.ToString()},
                    {"@message",alert.message },
                    {"@person_id",alert.person_id },

                };

            _connectionWrapper.ExecutAlertion(sql, parametrs);
        }



        public List<PersonReportAverageDTO> GetPersonByAverage()
        {
            string sql = @"SELECT person.full_name ,person.code_name, AVG(LENGTH(report.content)) AS  ""average""
                        FROM report 
                       JOIN person
                       ON report.reporter_id=person.id
                     GROUP BY report.reporter_id
                      HAVING average >100";

            List<PersonReportAverageDTO> listDto = new List<PersonReportAverageDTO>();
            var reader = _connectionWrapper.ExecuteSelect(sql);

            while (reader.Read())
            {
                var personReportAverageDTO = new PersonReportAverageDTO
                {
                    FullName = reader["full_name"].ToString(),
                    CodeName = reader["code_name"].ToString(),
                    Average = Convert.ToDouble(reader["average"])
                };

                listDto.Add(personReportAverageDTO); 
            }

            
            return listDto; 
        }
    }
}
