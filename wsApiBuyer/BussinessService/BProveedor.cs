using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using wsApiAutofin.Services;
using wsApiBuyer.Models;
using wsApiBuyer.Models.Proveedor;

namespace wsApiBuyer.BussinessService
{
    public class BProveedor
    {
        public static Respuesta obtenerPublicidad()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                DataSet dsResult;
                List<MPublicidad> lstProducto = new List<MPublicidad>();
                dsResult = HelperSql.ObtieneDataSet("[SP_OBTENER_PUBLICIDAD]");
                if (dsResult != null)
                {
                    respuesta.Ok = "SI";
                    respuesta.Mensaje = "Publicidad";
                    DataTable dt = dsResult.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            lstProducto.Add(new MPublicidad()
                            {
                                 Id  = item["Id"].ToString()
                                ,UrlFoto = item["UrlFoto"].ToString()
                                ,IdCatGerarquia = item["IdCatGerarquia"].ToString()
                                ,IdPCatProveedor = item["IdPCatProveedor"].ToString()
                            });
                        }
                        respuesta.Objeto = Newtonsoft.Json.JsonConvert.SerializeObject(lstProducto);
                    }
                    //respuesta.Objeto = Newtonsoft.Json.JsonConvert.SerializeObject(dsResult.Tables[0]);
                }
                else
                {
                    respuesta.Ok = "No";
                    respuesta.Mensaje = "No existe publicidad configurada";
                }

            }
            catch (Exception _exc)
            {
                respuesta.Ok = "No";
                respuesta.Mensaje = "No existe publicidad configurada";
            }
            return respuesta;
        }
    }
}
