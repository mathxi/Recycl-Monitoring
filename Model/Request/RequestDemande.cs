﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring.Model.Request
{
    public static class RequestDemande
    {
            public static string demandeApresDate(string afterdate, int toindex)
            {
                ConnectionDatabase co = new ConnectionDatabase();


                if (co.OpenConnection() == true)
                {
                    string command = "SELECT * FROM db.demande WHERE datedemande > :afterdate order by datedemande OFFSET :toindex ROWS FETCH NEXT 3 ROWS ONLY";
                    //Create Command
                    OracleCommand cmd = new OracleCommand(command, co.GetConnection());
                    cmd.Parameters.Add("date", afterdate);
                    cmd.Parameters.Add("page", toindex);
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

        public static string NombreDechetPourUneDemande(int idDemande)
        {
            ConnectionDatabase co = new ConnectionDatabase();

            if (co.OpenConnection() == true)
            {
                string command = @"select t4.raisonsociale, t3.notournee, t2.nomtypedechet, T1.quantiteenlevee from db.detaildemande T1 join db.typedechet T2 on T1.notypedechet = T2.notypedechet join db.demande T3 on t3.nodemande = t1.nodemande join db.entreprise T4 on t4.siret = t3.siret WHERE T1.nodemande = :nodemande";
                OracleCommand cmd = new OracleCommand(command, co.GetConnection());
                cmd.Parameters.Add("nodemande", idDemande);
                OracleDataReader reader = cmd.ExecuteReader();

                string json = RequestToJson.ToJson(reader);
                reader.Dispose();
                cmd.Dispose();
                co.CloseConnection();
                return json;

            }
            return "[]";
        }

        public static string DemandePasDansTournee()
        {
            ConnectionDatabase co = new ConnectionDatabase();

            if (co.OpenConnection() == true)
            {
                string command = @"select *
from db.demande
where notournee is null";
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
