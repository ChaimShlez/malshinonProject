using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using malshinonProject.Dal;
using malshinonProject.Entitys;

namespace malshinonProject.Logic
{
    internal class LogicAlert
    {
        private DalAlert _dalAlert;
        private DalAnalysis _dalAnalysis;

        public LogicAlert(DalAlert dalAlert  , DalAnalysis dalAnalysis)
        {
            _dalAlert = dalAlert;
            _dalAnalysis =dalAnalysis;
        }


        public List<Alert> GetAllAlerts()
        {
            List<Alert>alerts=_dalAlert.GetAllAlerts();
            return alerts;
        }

        public List<PersonReportAverageDTO> GetPersonByAverage()
        {

            List<PersonReportAverageDTO> list = _dalAnalysis.GetPersonByAverage();
            return list;
        }
    }
}
