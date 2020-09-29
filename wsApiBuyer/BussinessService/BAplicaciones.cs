using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using wsApiAutofin.Services;
using wsApiBuyer.Models;
using wsApiBuyer.Models.Aplicaciones;

namespace wsApiBuyer.BussinessService
{
    public static class BAplicaciones
    {
        public static Respuesta obtenerCatalogoAplicaciones()
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                DataSet dsResult;
                dsResult = HelperSql.ObtieneDataSet("[SP_OBTENER_CATALOGO_APLICACIONES]");
                List<MAplicacion> lstAplicacion = new List<MAplicacion>();
                if (dsResult != null)
                {
                    respuesta.Ok = "SI";
                    respuesta.Mensaje = "Prodcutos random";
                    DataTable dt = dsResult.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        respuesta.Ok = "SI";
                        respuesta.Mensaje = "Aplicaciones existentes";


                        foreach (DataRow item in dt.Rows)
                        {
                            if (!lstAplicacion.Any(c => c.Nombre == item["Nombre"].ToString()))
                            {
                                MAplicacion app = new MAplicacion()
                                {
                                    Id = item["Id"].ToString()
                                     ,
                                    Nombre = item["Nombre"].ToString()
                                     ,
                                    Alias = item["Alias"].ToString()
                                     ,
                                    Resumen = item["Resumen"].ToString()
                                     ,
                                    UrlAppsIOS = item["UrlAppsIOS"].ToString()
                                     ,
                                    UrlAppsAndroid = item["UrlAppsAndroid"].ToString()
                                     ,
                                    IdCatStatusApp = item["IdCatStatusApp"].ToString()
                                     ,
                                    UrlTerminos = item["UrlTerminos"].ToString()
                                     ,
                                    UrlPolitica = item["UrlPolitica"].ToString()
                                     ,
                                    ColorUnoHexadecimal = item["ColorUnoHexadecimal"].ToString()
                                     ,
                                    ColorDosHexadecimal = item["ColorDosHexadecimal"].ToString()
                                };
                                app.lstFotos = new List<MFotosAplicaciones>();
                                app.lstFotos.Add(new MFotosAplicaciones()
                                {
                                    UrlImagen = item["UrlImagen"].ToString()
                                });

                                lstAplicacion.Add(app);
                            }
                            else
                            {
                                lstAplicacion.Where(c => c.Nombre == item["Nombre"].ToString()).FirstOrDefault()
                                    .lstFotos.Add(new MFotosAplicaciones()
                                    {
                                        UrlImagen = item["UrlImagen"].ToString()
                                    });
                            }
                        }

                    }
                    respuesta.Objeto = Newtonsoft.Json.JsonConvert.SerializeObject(lstAplicacion);
                }
                else
                {
                    respuesta.Ok = "No";
                    respuesta.Mensaje = "No existe ningún producto";
                }

            }
            catch (Exception _exc)
            {
                respuesta.Ok = "No";
                respuesta.Mensaje = "No existe ningún producto";
            }
            return respuesta;
        }

        public static Respuesta enviarMensaje(MMensaje mMensaje)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                DataSet dsResult;
                dsResult = HelperSql.ObtieneDataSet("[SP_INSERTAR_MENSAJE_CONTACTO]", mMensaje.Nombre, mMensaje.Email, mMensaje.Telefono, mMensaje.Mensaje);
                if (dsResult != null)
                {
                    DataTable dt = dsResult.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        respuesta.Ok = "SI";
                        respuesta.Mensaje = dt.Rows[0]["Mensaje"].ToString();
                    }
                    else
                    {
                        respuesta.Ok = "No";
                        respuesta.Mensaje = "Por favor intentalo más tarde.";
                    }

                }
                else {
                    respuesta.Ok = "No";
                    respuesta.Mensaje = "Por favor intentalo más tarde.";
                }
            }
            catch (Exception _exc)
            {
                respuesta.Ok = "No";
                respuesta.Mensaje = "Por favor intentalo más tarde.";
            }
            return respuesta;
        }

    }
}
