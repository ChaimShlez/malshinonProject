using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bogus;
using malshinonProject.Entitys;
using malshinonProject.UI;
using static Mysqlx.Error.Types;

namespace malshinonProject.Dal
{
    internal class DalAlert
    {
        private ConnectionWrapper _connectionWrapper;

        public DalAlert(ConnectionWrapper connectionWrapper)
        {
            _connectionWrapper = connectionWrapper;
        }
        public Alert CreateAlertFromDangerousPerson()
        {
            Alert alert = null;
            string sql = @"SELECT person_report.person_id, COUNT(*) AS report_count 
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
    }
}
