using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using malshinonProject.Dal;
using malshinonProject.Entitys;

namespace malshinonProject.Logic
{
    internal class LogicReport
    {
        private DalReport _dalReport;

        public LogicReport(DalReport dalReport)
        {
            _dalReport = dalReport;
        }

        public void CreateReport(Person personRepoted,Report report, Person reporterPerson)
        {
            _dalReport.CreateReport(personRepoted,report, reporterPerson);
        }
    }
}
