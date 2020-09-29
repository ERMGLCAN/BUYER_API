using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wsApiBuyer.Models;
using wsApiBuyer.BussinessService;
using wsApiBuyer.Models.Aplicaciones;

namespace wsApiBuyer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AplicacionesController : ControllerBase
    {
        [HttpGet("obtenerCatalogoAplicaciones")]
        public Respuesta obtenerCatalogoAplicaciones()
        {

            return BAplicaciones.obtenerCatalogoAplicaciones();
        }

        [HttpPost("enviarMensaje")]
        public Respuesta enviarMensaje([FromBody] MMensaje mMensaje)
        {

            return BAplicaciones.enviarMensaje(mMensaje);
        }

    }
}