using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Monitoring.Controllers;

namespace Monitoring.Model
{
    class ConnectionDatabase
    {
            private OracleConnection connection;

            // Constructeur
            public ConnectionDatabase()
            {
                this.InitConnexion();
            }

            // Méthode pour initialiser la connexion
            private void InitConnexion()
            {
                // Création de la chaîne de connexion
                try
                {
                    this.connection = new OracleConnection("DATA SOURCE=90.93.155.0:1522/xe;PERSIST SECURITY INFO=True;USER ID=ADMINDB;password=mdpadmin!");
                }
                catch (InvalidCastException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //open connection to database
            public bool OpenConnection()
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (OracleException ex)
                {
                    Console.WriteLine(ex);
                //switch (ex.Number)
                //{
                //    case 0:
                //        Console.WriteLine("Cannot connect to server.  Contact administrator");
                //        break;

                //    case 1045:
                //        Console.WriteLine("Invalid username/password, please try again");
                //        break;
                //}
                    return false;
                }
            }

            //Close connection
            public bool CloseConnection()
            {
                try
                {
                    connection.Close();
                    return true;
                }
                catch (OracleException ex)
                {
                Console.WriteLine(ex.Message);
                    return false;
                }
            }

            public OracleConnection GetConnection()
            {
                return connection;
            }
         
    }
}
