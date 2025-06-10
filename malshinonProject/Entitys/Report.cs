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

        public Report()
        {
        }

        public Report(int reporterId, DateTime reoprtTime, string content)
        {
            ReporterId = reporterId;
            this.reoprtTime = reoprtTime;
            this.content = content;
           
        }

        public int id
        {
            get { return id; }
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

    }
}
