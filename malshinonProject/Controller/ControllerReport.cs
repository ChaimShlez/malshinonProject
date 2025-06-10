using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using malshinonProject.Entitys;
using malshinonProject.Logic;

namespace malshinonProject.Controller
{
    internal class ControllerReport
    {
        private LogicReport _logicReport;

        public ControllerReport(LogicReport logicReport)
        {
            _logicReport = logicReport;
        }

        public void CreateReport(Person personRepoted,Report report , Person reporterPerson)
        {
            _logicReport.CreateReport(personRepoted, report, reporterPerson);
        }
    }
}
