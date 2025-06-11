using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using malshinonProject.Enum;

namespace malshinonProject.Entitys
{
    internal class Alert
    {
		private int Id;

        private int ReportId;
        private DateTime AlertTime;
        private EnumSeverity Severity;
        private string Message;
        private int PersonId;
        private string City;

        public Alert(int reportId,  EnumSeverity severity, string message, int personId, string city)
        {

            ReportId = reportId;

            Severity = severity;
            Message = message;
            PersonId = personId;
            City = city;
        }

        public Alert(int report_id, DateTime alertTime, EnumSeverity severity, string message, int person_id)
        {
            this.report_id = report_id;
            this.alertTime = alertTime;
            this.severity = severity;
            this.message = message;
            this.person_id = person_id;
        }

        public Alert()
        {
        }

        public int id
		{
			get { return Id; }
            set { Id = value; }

        }

        public int report_id
        {
            get { return ReportId; }
            set { ReportId = value; }
        }

        

        public DateTime alertTime
        {
            get { return AlertTime; }
            set { AlertTime = value; }
        }

      

        public EnumSeverity severity
        {
            get { return Severity; }
            set { Severity = value; }
        }
            

          

        public string message
        {
            get { return Message; }
            set { Message = value; }
        }
        public int person_id
        {
            get { return PersonId; }
            set { PersonId = value; }

        }

        public string city
        {
            get { return City; }
            set { City = value; }

        }
    }


    
}
