using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace malshinonProject.Dal
{
    internal class ConnectionWrapper
    {
        private static ConnectionWrapper instance = null;
        private readonly string  ConnectionString= "server=localhost;user=root;database=malshinon;port=3306";

        private ConnectionWrapper() { }

        public static ConnectionWrapper getInstance()
        {
            if (instance == null)
            {
                instance = new ConnectionWrapper();
            }
              
            return instance;
        }

        public long ExecutAlertion(string sql, Dictionary<string, object> paramters)
        {
            var connection = new MySqlConnection(ConnectionString);
            try
            {
               
                connection.Open();
                var cmd = new MySqlCommand(sql, connection);

                foreach (var param in paramters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
                 cmd.ExecuteNonQuery();
                return cmd.LastInsertedId;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"filed alertion , {ex.Message}");
                throw;

            }
            //finally{
            //    connection.Close();
            //}

        }

        public MySqlDataReader ExecuteSelect(string sql, Dictionary<string, object> paramters=null)
        {
            var connection = new MySqlConnection(ConnectionString);
           
            try
            {
                connection.Open();
                var cmd = new MySqlCommand(sql, connection);

                if (paramters != null)
                {
                    foreach (var param in paramters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value);
                    }
                   
                }
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"filed select , {ex.Message}");
                throw;
            }
            

        }


    }
}
