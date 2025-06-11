using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using malshinonProject.Entitys;
using malshinonProject.Enum;
using malshinonProject.UI;
using static Mysqlx.Error.Types;

namespace malshinonProject.Dal
{
    internal class DalAlert
    {
        private ConnectionWrapper _connectionWrapper;

        public DalAlert(ConnectionWrapper connectionWrapper)
        {
            _connectionWrapper = connectionWrapper;
        }

        public List<Alert> GetAllAlerts()
        {
            List<Alert> alerts = new List<Alert>();
            string sql = @"SELECT * FROM alert";
            var reader = _connectionWrapper.ExecuteSelect(sql);

            if (reader != null)
            {
                while (reader.Read())
                {
                    Alert alert = new Alert(
                        reader.GetInt32("report_id"),
                        reader.GetDateTime("alert_time"),
                        (EnumSeverity)System.Enum.Parse(typeof(EnumSeverity), reader.GetString("severity")),
                        reader.GetString("message"),
                        reader.GetInt32("person_id"),
                        reader.GetString("city")
                    );

                    alerts.Add(alert);
                }
            }

            return alerts;
        }
    }
}


