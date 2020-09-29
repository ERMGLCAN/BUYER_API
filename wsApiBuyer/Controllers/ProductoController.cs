using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wsApiBuyer.BussinessService;
using wsApiBuyer.Models;

namespace wsApiBuyer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        [HttpGet("obtenerProductos")]
        public Respuesta GetProductosRandom() {

            return  BProducto.ObtenerProductos();
        }

        [HttpGet("GetProductosLike")]
        public Respuesta GetProductosLike(String value)
        {

            return BProducto.GetProductosLike(value);
        }

        [HttpGet("GetProductosInicial")]
        public Respuesta GetProductosInicial(String value)
        {

            return BProducto.GetProductosLike(value);
        }



    }
}
