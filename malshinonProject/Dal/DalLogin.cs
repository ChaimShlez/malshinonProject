using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using malshinonProject.Entitys;

namespace malshinonProject.Dal
{
    internal class DalLogin
    {

       private ConnectionWrapper _connectionWrapper;

        public DalLogin(ConnectionWrapper connectionWrapper)
        {
            _connectionWrapper = connectionWrapper;
        }

        public Person Login(string codeName)
        {
            Person person =null;
            string sql = @"SELECT * FROM person WHERE code_name = @code_name";
            var param = new Dictionary<string, object>
            {
               { "@code_name", codeName }
             };

            var reader = _connectionWrapper.ExecuteSelect(sql, param);
            if (reader != null)
            {
                while (reader.Read())
                {
                    person = new Person
                    {
                        Id = reader.GetInt32("Id"),
                        FullName = reader.GetString("full_name"),
                        CodeName = reader.GetString("code_name"),
                        PhoneNumber = reader.GetString("phone_number"),

                    };


                }
                return person;
            }
            else
            {
                return null;
            }
            
        }

    }
}
