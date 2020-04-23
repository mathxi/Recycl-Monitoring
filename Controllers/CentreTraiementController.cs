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

namespace Monitoring.Controllers
{
    public class CentreTraitementController : ControllerBase
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/[controller]/getcentretraitement")]
        [HttpGet]
        public string Get()
        {
            return RequestCentreTraitement.CentreTraitement();
        }
    }
}
