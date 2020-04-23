using System.Collections.Generic;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Mvc;
using Monitoring.Model.Request;

namespace Monitoring.Controllers
{

    //[ApiController]
    public class EmployeController : ControllerBase
    {
        // GET: api/Employe
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/[controller]/getemployentournee")]
        [HttpGet]
        public string Get(int nbTournee)
        {
            return RequestEmploye.employeavecmoinsdentournee(nbTournee);
        }
        
    }
}
