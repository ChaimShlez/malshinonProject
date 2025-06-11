using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using malshinonProject.Dal;
using malshinonProject.Entitys;

namespace malshinonProject.Logic
{
    internal class LogicAnalysis
    {

        private DalAnalysis _dalAlert;

        public LogicAnalysis(DalAnalysis dalAlert)
        {
            _dalAlert = dalAlert;
        }

        public void runByTimeZon()
        {
            DateTime utcTime = DateTime.UtcNow;

            TimeZoneInfo israelTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Israel Standard Time");
            
            DateTime israelTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, israelTimeZone);

            int hour = israelTime.Hour;
            int minuts = israelTime.Minute;
            int second = israelTime.Second;

            if (hour == 00 && minuts == 00 && second == 00)
            {
                AnalysisManager();
            }
        }

        public string GetMeesage(Alert alert)
        {
            Dictionary<int, string> messageFromAlert = new Dictionary<int, string>
            {
                {alert.person_id,"This man is very dangerous, he appeared in a large number of reports"},
                {alert.report_id ,"The report was reported by a high amount of reporters" }
            };
            string message = "";



            if (alert.person_id != 0)
            {
                message = messageFromAlert[alert.person_id];
            }
            else
            {
                message = messageFromAlert[alert.report_id];
            }
            return message;
        }

        public void CreateAlertFromDangerousCity()
        {
            Alert alert = _dalAlert.CreateAlertFromDangerousCity();
            string messageFromCity= "This city appeared in a high number of reports";
            alert = new Alert(alert.report_id, alert.severity, messageFromCity, alert.person_id, alert.city);
            _dalAlert.saveAlert(alert);
        }
        public void CreateAlertFromDangerousPerson()
        {
            Alert alert = _dalAlert.CreateAlertFromDangerousPerson();
            string message = GetMeesage(alert);

            alert = new Alert(alert.report_id,alert.severity, message, alert.person_id,alert.city);
            _dalAlert.saveAlert(alert);
        }

        public void CreateAlertFromDangerousReprot()
        {
            Alert alert = _dalAlert.CreateAlertFromDangerousReport();
            string message = GetMeesage(alert);

            alert = new Alert(alert.report_id, alert.severity, message, alert.person_id, alert.city);
            _dalAlert.saveAlert(alert);
        }

        public void AnalysisManager()
        {
            CreateAlertFromDangerousCity();
            CreateAlertFromDangerousPerson();
        }
    }
}
