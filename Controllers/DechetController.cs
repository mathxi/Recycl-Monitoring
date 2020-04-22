using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Model;
using Oracle.ManagedDataAccess.Client;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monitoring.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/[controller]")]
    public class DechetController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get()
        {



            ConnectionDatabase co = new ConnectionDatabase();


            if (co.OpenConnection() == true)
            {
                string command = "select * from db.camion;";
                //Create Command
                OracleCommand cmd = new OracleCommand(command, co.GetConnection());

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetValue(0));
                }
                reader.Dispose();
                cmd.Dispose();
                co.CloseConnection();
            }
            Person person = new Person { Name = "Ana" ,Surname ="Maréchaall"};
            Person person2 = new Person { Name = "Ananeu", Surname = "Maréchaalleuuuu" };
            List<Person> persons = new List<Person> { person, person2};
            return persons;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
