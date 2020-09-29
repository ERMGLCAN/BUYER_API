using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace wsApiBuyer.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        [HttpGet("Test")]
        public ActionResult<List<String>> ObtenerTest() {
            List<String> ok = new List<string> {
                "uno"
               ,"dos"
               ,"tres"
            };

            return Ok(ok);
        }
    }
}