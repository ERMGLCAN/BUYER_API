using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wsApiBuyer.BussinessService;
using wsApiBuyer.Models;

namespace wsApiBuyer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        [HttpGet("obtenerPublicidad")]
        public Respuesta obtenerPublicidad()
        {

            return BProveedor.obtenerPublicidad();
        }
    }
}