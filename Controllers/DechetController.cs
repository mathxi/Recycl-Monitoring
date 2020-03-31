using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monitoring.Controllers
{
    [Route("api/[controller]")]
    public class DechetController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<Person> Get()
        {
            Person person = new Person { Name = "Ana" ,Surname ="Maréchaall"};
            return person;
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
