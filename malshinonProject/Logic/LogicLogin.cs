using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using malshinonProject.Dal;
using malshinonProject.Entitys;

namespace malshinonProject.Logic
{
    internal class LogicLogin
    {
        private DalLogin _dalLogin;

        public LogicLogin(DalLogin dalLogin)
        {
            _dalLogin = dalLogin;
        }

        public Person Login(string codeName)
        {

            
            return _dalLogin.Login(codeName);
        }
    }
}
