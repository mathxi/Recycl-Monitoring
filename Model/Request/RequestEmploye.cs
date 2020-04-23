using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring.Model.Request
{
    public static class RequestEmploye
    {
        public static string employeavecmoinsdentournee( int nbTournee)
        {
            ConnectionDatabase co = new ConnectionDatabase();


            if (co.OpenConnection() == true)
            {
                string command = @"select t1.noemploye ,t1.nom, t1.prenom, t1.datenaiss, t1.dateembauche, t1.salaire, t1.nofonction  , (SELECT COUNT(T2.notournee) from db.tournee T2 where T2.noemploye = t1.noemploye) as nbResultat
FROM db.employe T1
WHERE
(SELECT COUNT(T2.notournee) from db.tournee T2 where T2.noemploye = t1.noemploye) < :notournee
            ORDER BY
            (SELECT COUNT(T2.notournee) from db.tournee T2 where T2.noemploye = t1.noemploye) desc";
                //Create Command
                OracleCommand cmd = new OracleCommand(command, co.GetConnection());
                cmd.Parameters.Add("nbtournee", nbTournee);
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
