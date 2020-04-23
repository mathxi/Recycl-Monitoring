using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Model.Request;


namespace Monitoring.Controllers
{
    public class EntrepriseController : ControllerBase
    {
        // GET: api/Entreprise
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/[controller]/plusdedemandeque")]
        [HttpGet]
        public string EntrepriseAvecPlusdeDemandeQue(string raisonsociale)
        {
            return RequestEntreprise.EntrepriseAvecPlusDeDemandeQue(raisonsociale);
        }

        // GET: api/Entreprise/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Entreprise
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Entreprise/5
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
