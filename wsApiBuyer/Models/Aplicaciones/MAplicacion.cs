using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wsApiBuyer.Models.Aplicaciones
{
    public class MAplicacion
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Alias { get; set; }        
        public string Resumen { get; set; }
        public string UrlAppsIOS { get; set; }
        public string UrlAppsAndroid { get; set; }
        public string IdCatStatusApp { get; set; }
        public string UrlTerminos { get; set; }
        public string UrlPolitica { get; set; }
        public string ColorUnoHexadecimal { get; set; }
        public string ColorDosHexadecimal { get; set; }

        public List<MFotosAplicaciones> lstFotos { get; set; }

    }
}
