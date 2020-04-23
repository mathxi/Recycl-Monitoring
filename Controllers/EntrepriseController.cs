using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Model.Request;


namespace Monitoring.Controllers
{
    public class EntrepriseController : ControllerBase
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/[controller]/plusdedemandeque")]
        [HttpGet]
        public string EntrepriseAvecPlusdeDemandeQue(string raisonsociale)
        {
            return RequestEntreprise.EntrepriseAvecPlusDeDemandeQue(raisonsociale);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/[controller]/getentreprises")]
        [HttpGet]
        public string getentreprises()
        {
            return RequestEntreprise.Entreprises();
        }
    }
}
