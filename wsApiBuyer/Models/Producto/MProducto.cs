using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wsApiBuyer.Models.Producto
{
    public class MProducto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string RutaFoto { get; set; }
        public string Precio { get; set; }
        public string Iva { get; set; }
        public string PrecioConIva { get; set; }
        public string PrecioMayoreo { get; set; }
        public string CantidadMinMayoreo { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string IdProdCampania { get; set; }
        public string IdProdCatSubcategoria { get; set; }
        public string FolioProducto { get; set; }
        public string IdPCatProveedor { get; set; }
        public string Descuento { get; set; }
        public string Caduca { get; set; }
        public string NombreComercial { get; set; }
        public string RutaFotoLogo{ get; set; }
        public string IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string IdSubcategoria { get; set; }
        public string Subcategoria { get; set; }

        public List<Filtro> lstFiltros { get; set; }
    }

    public class Filtro {
        public string IdFiltro { get; set; }
        public string NombreFiltro { get; set; }
        public List<ValorFiltro> lstValores { get; set; }

    }

    public class ValorFiltro {
        public string IdValor { get; set; }
        public string NombreValor { get; set; }
        public string Valor { get; set; }
        public string RutaFotoValor { get; set; }

    }


}
