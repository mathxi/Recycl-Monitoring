using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Model.Request;

namespace Monitoring.Controllers
{
    public class DemandeController : ControllerBase
    {
        // GET: api/Demande

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/[controller]/getdemandesanstournee")]
        [HttpGet]
        public string DemandeSansTournee()
        {
            return RequestDemande.DemandePasDansTournee();
        }

        // GET: api/Demande/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Demande
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Demande/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
