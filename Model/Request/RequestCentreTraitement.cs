using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring.Model.Request
{
    public class RequestCentreTraitement
    {

        public static string CentreTraitement()
        {
            ConnectionDatabase co = new ConnectionDatabase();


            if (co.OpenConnection() == true)
            {
                string command = @"select * from db.centretraitement";

                OracleCommand cmd = new OracleCommand(command, co.GetConnection());
                OracleDataReader reader = cmd.ExecuteReader();

                string json = RequestToJson.ToJson(reader);
                reader.Dispose();
                cmd.Dispose();
                co.CloseConnection();
                return json;
            }
            return "[]";
        }
    }
}
