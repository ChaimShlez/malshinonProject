using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Google.Protobuf.Compiler;
using malshinonProject.Dal;
using malshinonProject.Entitys;
using malshinonProject.Enum;
using malshinonProject.UI;



namespace malshinonProject.Logic
{
    internal class LogicRegister
    {
        private DalRegister  _dalRegister;
        private Faker faker = new Faker();

        public LogicRegister(DalRegister dalRegister)
        {
            _dalRegister = dalRegister;
        }

        public bool IsExsistPhoneNumber(Entitys.Person person)
        {
            
            return   _dalRegister.IsExsistPhoneNumber(person.PhoneNumber);
        }

        public string RegisterPerson(Entitys.Person person)
        {

            //validatePerson(person, phone);
            string codeName = "";
            bool isExistPhoneNumberInDB = false;
            if (person.Type == EnumReporterType.reported)
            {
                isExistPhoneNumberInDB = IsExsistPhoneNumber(person);

                if (isExistPhoneNumberInDB)
                {
                    codeName = _dalRegister.GetCodeNameByPhoneNumer(person.PhoneNumber);
                }
                else {
                    codeName = savePerson(person);
                    return codeName;
                }


            }
            else
            {
                codeName = savePerson(person);
                
            }
            return codeName;
        }

        //private void validatePerson(Entitys.Person person, string phone)
        //{
        //    if (person.PhoneNumber == phone)
        //    {
        //        throw new Exception($"phone is failed{person.PhoneNumber} ");
        //    }
        //}

        public string savePerson(Entitys.Person person)
        {
            string codeName = "";
            bool isExist = false;
            while (!isExist)
            {
                string fakeCodeName = faker.Name.FirstName();
              
                bool isExistInDB = _dalRegister.IsExsistCodeName(fakeCodeName);
                if (!isExistInDB)
                {
                    codeName = fakeCodeName;
                    isExist = true;
                }
            }
           

            Entitys.Person newPerson = new Entitys.Person(person.FullName, codeName, person.PhoneNumber, person.Type);

            string CodeName = _dalRegister.SavePerson(newPerson);
            //Console.WriteLine("vvvv"  +  CodeName);
            return CodeName;
        }
    }

    
}
