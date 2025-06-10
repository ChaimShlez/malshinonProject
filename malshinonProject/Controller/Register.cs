using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using malshinonProject.Entitys;
using malshinonProject.Logic;

namespace malshinonProject.Controller
{
    internal class Register
    {
        private LogicRegister _logikRegister;

        public Register(LogicRegister logikRegister)
        {
            _logikRegister = logikRegister;
        }

        public string RegisterPerson (Person person)
        {
           string codeName= _logikRegister.RegisterPerson(person);
            return codeName;

        }
    }
}
