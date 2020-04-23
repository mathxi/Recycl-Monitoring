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


    public class DechetController : Controller
    {
        // GET: api/<controller>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/[controller]")]
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "[]";
        }

        // GET api/<controller>/18/05/18
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/[controller]/getbydate")]
        public string Get(DateTime date)
        {
            return "[]";
        }

        // POST api/<controller>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/[controller]/getafterdate")]
        public string getafterdate(string date, int page)
        {
            return RequestDemande.demandeApresDate(date, page);
        }

        // POST api/<controller>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/[controller]/getdechetdemande")]
        public string getdechetdemande(int idDemande)
        {
            return RequestDemande.NombreDechetPourUneDemande(idDemande);
        }

        // POST api/<controller>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/[controller]/getdechetcentreperiode")]
        public string getDechetPourUnCentrePourUnePeriode(string datedebut,string datefin, int centre, int typedechet)
        {
            return RequestDechet.QuantiteDechetPourUnCentrePourUnePeriode(datedebut, datefin, centre, typedechet);
        }

        // POST api/<controller>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/[controller]/getdechetpourperiode")]
        public string getdechetpourperiode(string datedebut, string datefin)
        {
            return RequestDechet.QuantiteDechetPourMoisAnnee(datedebut, datefin);
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
