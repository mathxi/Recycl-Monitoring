using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring.Model.Request
{
    public class RequestEntreprise
    {
        public static string Entreprises()
        {
            ConnectionDatabase co = new ConnectionDatabase();


            if (co.OpenConnection() == true)
            {
                string command = @"select* from db.entreprise";

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
        
        public static string EntrepriseAvecPlusDeDemandeQue(string raisonsociale)
        {
            ConnectionDatabase co = new ConnectionDatabase();


            if (co.OpenConnection() == true)
            {
                string command = @"select *
from db.Entreprise t1
where 
( Select COUNT(nodemande) from db.demande where siret = t1.siret ) > ( Select COUNT(nodemande) from db.demande join db.entreprise on entreprise.siret = demande.siret   where entreprise.raisonsociale = :raisonsociale )
";

                OracleCommand cmd = new OracleCommand(command, co.GetConnection());
                cmd.Parameters.Add("raisonsociale", raisonsociale);
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
