using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using malshinonProject.Entitys;

namespace malshinonProject.Dal
{
    internal class DalRegister
    {

        private ConnectionWrapper  _connectionWrapper;

        public DalRegister(ConnectionWrapper connectionWrapper)
        {
            _connectionWrapper = connectionWrapper;
        }


        public bool IsExsistCodeName(string codeName)
        {
           
            string sql = @" SELECT * FROM person WHERE code_name = @code_name";
            var param = new Dictionary<string, object>
            {
               { "@code_name", codeName } 
             };

            var reader = _connectionWrapper.ExecuteSelect(sql, param);
            return reader != null && reader.Read();
        }

        public bool IsExsistPhoneNumber(string phoneNumber)
        {

            string sql = @" SELECT * FROM person WHERE phone_number = @phone_number";
            var param = new Dictionary<string, object>
            {
               { "@phone_number", phoneNumber }
             };

            var reader = _connectionWrapper.ExecuteSelect(sql, param);
            return reader != null && reader.Read();
        }

        
        public string GetCodeNameByPhoneNumer(string phoneNumber)
        {
            string sql = @"SELECT code_name FROM person WHERE phone_number = @phone_number";

            var parameters = new Dictionary<string, object>
            {
                {"@phone_number" ,phoneNumber }
            };


            var reader = _connectionWrapper.ExecuteSelect(sql, parameters);


            
            return reader["code_name"].ToString();
            
        }



        public string SavePerson(Entitys.Person person)
        {
           
            
            string sql = @"INSERT INTO person (full_name,Code_name,phone_number,type)
                             VALUES(@FullName,@CodeName,@PhoneNumber,@Type)";

            var parametrs = new Dictionary<string, object>
                {
                    {"@FullName",person.FullName },
                    {"@CodeName",person.CodeName },
                    {"@PhoneNumber",person.PhoneNumber },
                    {"@Type",person.Type.ToString() },

                };

            long affected =_connectionWrapper.ExecutAlertion(sql, parametrs);

            if (affected > 0)
            {
                
                return person.CodeName;
               
            }
            else
            {
                return null;
            }
        }
    }
}
