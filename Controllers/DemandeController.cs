using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Model.Request;

namespace Monitoring.Controllers
{
    public class DemandeController : ControllerBase
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/[controller]/getdemandesanstournee")]
        [HttpGet]
        public string DemandeSansTournee()
        {
            return RequestDemande.DemandePasDansTournee();
        }
    }
}
