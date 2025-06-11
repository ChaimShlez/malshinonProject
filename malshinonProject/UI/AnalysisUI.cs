using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using malshinonProject.Controller;
using malshinonProject.Entitys;

namespace malshinonProject.UI
{
    internal class AnalysisUI
    {
        private ControllerAlert _controlleerAlert;

        public AnalysisUI(ControllerAlert controlleerAlert)
        {
            _controlleerAlert = controlleerAlert;
        }

        public void GetAnalysis()
        {
           
           List<Alert>alerts = _controlleerAlert.GetAllAlerts();


           foreach(var item in alerts)
           {
                Console.WriteLine(item);
           }

        }
    }
}
