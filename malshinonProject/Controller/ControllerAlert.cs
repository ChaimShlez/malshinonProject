using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using malshinonProject.Entitys;
using malshinonProject.Logic;

namespace malshinonProject.Controller
{
    internal class ControllerAlert
    {
        private LogicAlert _logicAlert;

        public ControllerAlert(LogicAlert logicAlert)
        {
            _logicAlert = logicAlert;
        }


        public List<Alert> GetAllAlerts()
        {
            List<Alert> alrets = _logicAlert.GetAllAlerts();
            return alrets;
        }


        public List<PersonReportAverageDTO> GetPersonByAverage()
        {
            List <PersonReportAverageDTO> list= _logicAlert.GetPersonByAverage();
            return list;
        }
    }
}
