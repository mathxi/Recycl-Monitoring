using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Model
{
    public static class RequestToJson
    {
        public static String ToJson(OracleDataReader reader)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.WriteStartArray();

                while (reader.Read())
                {
                    jsonWriter.WriteStartObject();

                    int fields = reader.FieldCount;
                    //var value = reader[3];
                    for (int i = 0; i < fields; i++)
                    {
                        jsonWriter.WritePropertyName(reader.GetName(i));

                        if(reader[i] is System.DBNull)
                        {
                            jsonWriter.WriteValue("");
                        }
                        else
                        {
                            jsonWriter.WriteValue(reader[i]);
                        }
                    }

                    jsonWriter.WriteEndObject();
                }

                jsonWriter.WriteEndArray();

                return sw.ToString();
            }
        }
    }
}
