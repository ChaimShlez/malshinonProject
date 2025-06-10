using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using malshinonProject.Controller;
using malshinonProject.Dal;
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


            DalRegister dalRegister = new DalRegister(connection);
            LogicRegister logicRegister = new LogicRegister(dalRegister);
            Register register = new Register(logicRegister);

            HomePage homePage = new HomePage(login, register);

            homePage.Menu();
        }
    }
}
