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

        public Alert()
        {
        }

        public int id
		{
			get { return Id; }
			
		}

        public int reportId
        {
            get { return ReportId; }
            
        }

        

        public DateTime alertTime
        {
            get { return AlertTime; }
            
        }

      

        public EnumSeverity severity
        {
            get { return Severity; }
        }
            

          

        public string message
        {
            get { return Message; }
            
        }
    }


    
}
