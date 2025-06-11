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

        public LogicAlert(DalAlert dalAlert)
        {
            _dalAlert = dalAlert;
        }


        public List<Alert> GetAllAlerts()
        {
            List<Alert>alerts=_dalAlert.GEtAllAlerts();
            return alerts;
        }
    }
}
