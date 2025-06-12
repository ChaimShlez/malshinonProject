using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using malshinonProject.Controller;
using malshinonProject.Dal;
using malshinonProject.Entitys;
using malshinonProject.Logic;
using malshinonProject.UI;

namespace malshinonProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionWrapper connection = ConnectionWrapper.getInstance();
            DalLogin dal = new DalLogin(connection);
            LogicLogin logic = new LogicLogin(dal);
            ControllerLogin login = new ControllerLogin(logic);

            DalReport dalReport = new DalReport(connection);
            LogicReport logicReport = new LogicReport(dalReport);
            ControllerReport controllerReport = new ControllerReport(logicReport);

            DalRegister dalRegister = new DalRegister(connection);
            LogicRegister logicRegister = new LogicRegister(dalRegister);
            Register register = new Register(logicRegister);

            Report report = new Report();
            DalAlert dalAlert = new DalAlert(connection);
            DalAnalysis dalAnalysis = new DalAnalysis(connection);
            LogicAlert logicAlert = new LogicAlert(dalAlert , dalAnalysis);
            ControllerAlert controlleerAlert = new ControllerAlert(logicAlert);

        ReportUI reportUI = new ReportUI(login,register, controllerReport);
            AnalysisUI analysisUI = new AnalysisUI(controlleerAlert);

            HomePage homePage = new HomePage(login, register, reportUI, analysisUI);

            DalAnalysis analysis = new DalAnalysis(connection);
            LogicAnalysis logicAnalysis = new LogicAnalysis(analysis);
            logicAnalysis.runByTimeZon();
            homePage.Menu();


            
        }
    }
}
