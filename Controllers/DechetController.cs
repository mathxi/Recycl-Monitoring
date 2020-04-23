using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Model;
using Monitoring.Model.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public ActionResult<string> Get()
        {
            return "[]";
        }

        // GET api/<controller>/18/05/18
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet("{date}")]
        [Route("api/[controller]/getbydate")]
        public string Get(DateTime date)
        {
            return "[]";
        }

        // POST api/<controller>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/[controller]/getafterdate")]
        public static ActionResult<string> Post([FromBody] DateTime date ,int page)
        {
            return RequestDemande.demandeApresDate(date, page);
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
}
