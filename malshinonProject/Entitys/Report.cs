using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace malshinonProject.Entitys
{
    internal class Report
    {
		private int Id;

        private int ReporterId;
        private DateTime ReoprtTime;

        private string Content;
        private string City;

        public Report()
        {
        }

        public Report(int reporterId, DateTime reoprtTime, string content, string city)
        {
            ReporterId = reporterId;
            this.reoprtTime = reoprtTime;
            this.content = content;
            City = city; 
        }

        public int id
        {
            get { return Id; }
        }

      

        public int reporterId
        {
            get { return ReporterId; }
            
        }

       

        public DateTime reoprtTime
        {
            get { return ReoprtTime; }
            set { ReoprtTime = value; }
        }

        

        public string content
        {
            get { return Content; }
            set { Content = value; }
        }

        public string city
        {
            get { return City; }
            set { City = value; }
        }

    }
}
