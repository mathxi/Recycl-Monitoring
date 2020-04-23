using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring.Model.Request
{
    public class RequestDechet
    {

        public static string QuantiteDechetPourMoisAnnee(string datedebut, string datefin)
        {
            ConnectionDatabase co = new ConnectionDatabase();


            if (co.OpenConnection() == true)
            {
                string command = @"SELECT t3.nomtypedechet , SUM(t1.quantiteenlevee)
FROM db.detaildemande t1
join db.demande t2 on t1.nodemande = t2.nodemande
join db.typedechet t3 on t1.notypedechet = t3.notypedechet
WHERE
t2.dateenlevement > :datedebut
and t2.dateenlevement < :datefin
group by t3.nomtypedechet";
                
                OracleCommand cmd = new OracleCommand(command, co.GetConnection());
                cmd.Parameters.Add("datedebut", datedebut);
                cmd.Parameters.Add("datefin", datefin);
                OracleDataReader reader = cmd.ExecuteReader();
               
                string json = RequestToJson.ToJson(reader);
                reader.Dispose();
                cmd.Dispose();
                co.CloseConnection();
                return json;
            }
            return "[]";
        }

        public static string QuantiteDechetPourUnCentrePourUnePeriode(string datedebut,string datefin, int centre, int notypedechet)
        {
            ConnectionDatabase co = new ConnectionDatabase();


            if (co.OpenConnection() == true)
            {
                string command = @" SELECT SUM(t1.quantitedeposee) AS Quantite
FROM db.detaildepot t1
JOIN db.centretraitement t2 on t1.nocentre = t2.nocentre
join db.tournee t3 on t3.notournee = t1.notournee
join db.demande t4 on t4.notournee = t3.notournee
WHERE
t4.dateenlevement > :datedebut
and t4.dateenlevement< :datefin
and t1.notypedechet = :notypedechet
and t1.nocentre = :nocentre";

                OracleCommand cmd = new OracleCommand(command, co.GetConnection());
                cmd.Parameters.Add("datedebut", datedebut);
                cmd.Parameters.Add("datefin", datefin);
                cmd.Parameters.Add("notypedechet", notypedechet);
                cmd.Parameters.Add("nocentre", centre);

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
