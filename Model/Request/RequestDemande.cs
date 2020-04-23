using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring.Model.Request
{
    public static class RequestDemande
    {
        public static string demandeApresDate(DateTime date, int page)
        {
            ConnectionDatabase co = new ConnectionDatabase();


            if (co.OpenConnection() == true)
            {
                string command = "SELECT * FROM db.demande WHERE datedemande > :date order by datedemande OFFSET :page ROWS FETCH NEXT 10 ROWS ONLY";
                //Create Command
                OracleCommand cmd = new OracleCommand(command, co.GetConnection());
                cmd.Parameters.Add("date", date);
                cmd.Parameters.Add("page", page);
                OracleDataReader reader = cmd.ExecuteReader();
                /*
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetValue(0));
                }*/
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
