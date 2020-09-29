using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using wsApiAutofin.Services;
using wsApiBuyer.Helper;
using wsApiBuyer.Models;
using wsApiBuyer.Models.Producto;

namespace wsApiBuyer.BussinessService
{
    public static class BProducto
    {

        public static Respuesta ObtenerProductos() {
            Respuesta respuesta = new Respuesta();
            try
            {
                DataSet dsResult;
                List<MProducto> lstProducto = new List<MProducto>();
                dsResult = HelperSql.ObtieneDataSet("[SP_OBTENER_PRODUCTOS_RANDOM]");
                if (dsResult != null)
                {
                    respuesta.Ok = "SI";
                    respuesta.Mensaje = "Prodcutos random";
                    DataTable dt = dsResult.Tables[0];                    
                    if (dt.Rows.Count > 0) {
                        foreach (DataRow item in dt.Rows)
                        {
                            if (lstProducto.Count > 0) {
                                var exist = lstProducto.Where(c => c.Id == item["Id"].ToString()).FirstOrDefault();

                                if (exist == null)
                                {
                                    #region add product
                                    MProducto p = new MProducto()
                                    {
                                        Id = item["Id"].ToString()
                                  ,
                                        Nombre = item["Nombre"].ToString()
                                  ,
                                        Descripcion = item["Descripcion"].ToString()
                                  ,
                                        RutaFoto = item["RutaFoto"].ToString()
                                  ,
                                        Precio = item["Precio"].ToString()
                                  ,
                                        Iva = item["Iva"].ToString()
                                  ,
                                        PrecioConIva = item["PrecioConIva"].ToString()
                                  ,
                                        PrecioMayoreo = item["PrecioMayoreo"].ToString()
                                  ,
                                        CantidadMinMayoreo = item["CantidadMinMayoreo"].ToString()
                                  ,
                                        FechaInicio = item["FechaInicio"].ToString()
                                  ,
                                        FechaFin = item["FechaFin"].ToString()
                                  ,
                                        IdProdCampania = item["IdProdCampania"].ToString()
                                  ,
                                        IdProdCatSubcategoria = item["IdProdCatSubcategoria"].ToString()
                                  ,
                                        FolioProducto = item["FolioProducto"].ToString()
                                  ,
                                        IdPCatProveedor = item["IdPCatProveedor"].ToString()
                                  ,
                                        Descuento = item["Descuento"].ToString()
                                  ,
                                        Caduca = item["Caduca"].ToString()
                                  ,
                                        NombreComercial = item["NombreComercial"].ToString()
                                  ,
                                        RutaFotoLogo = item["RutaFotoLogo"].ToString()
                                  ,
                                        IdCategoria = item["IdCategoria"].ToString()
                                  ,
                                        Categoria = item["Categoria"].ToString()
                                  ,
                                        IdSubcategoria = item["IdCatSubcategoria"].ToString()
                                  ,
                                        Subcategoria = item["Subcategoria"].ToString()
                                    };
                                     Filtro f = new Filtro()
                                    {
                                        IdFiltro = item["IdFiltro"].ToString()
                                       ,NombreFiltro = item["TituloFiltro"].ToString()                                     
                                    };

                                    ValorFiltro v = new ValorFiltro() {
                                    IdValor = item["IdValor"].ToString()
                                    ,NombreValor = item["NombreValor"].ToString()
                                    ,Valor = item["ValorFiltro"].ToString()
                                    ,RutaFotoValor = item["RutaFotoValor"].ToString()
                                };
                                    f.lstValores = new List<ValorFiltro>();
                                    f.lstValores.Add(v);
                                    p.lstFiltros = new List<Filtro>();
                                    p.lstFiltros.Add(f);
                                    lstProducto.Add(p);
                                    #endregion
                                }
                                else {

                                   var existFiltro =  lstProducto.Where(c => c.Id == item["Id"].ToString()).FirstOrDefault().lstFiltros.Where(c=> c.IdFiltro == item["IdFiltro"].ToString()).ToList();
                                    if (existFiltro.Count() > 0)
                                    {
                                        ValorFiltro v = new ValorFiltro() {
                                            IdValor = item["IdValor"].ToString()
                                            ,NombreValor = item["NombreValor"].ToString()
                                            ,Valor = item["ValorFiltro"].ToString()
                                            ,RutaFotoValor = item["RutaFotoValor"].ToString()
                                };
                                        lstProducto.Where(c => c.Id == item["Id"].ToString()).FirstOrDefault()
                                            .lstFiltros.Where(c => c.IdFiltro == item["IdFiltro"].ToString()).FirstOrDefault().lstValores.Add(v);
                                    }
                                    else {
                                        Filtro f = new Filtro()
                                        {
                                        IdFiltro = item["IdFiltro"].ToString()
                                       ,NombreFiltro = item["TituloFiltro"].ToString()                                     
                                        };

                                        ValorFiltro v = new ValorFiltro() {
                                        IdValor = item["IdValor"].ToString()
                                        ,NombreValor = item["NombreValor"].ToString()
                                        ,Valor = item["ValorFiltro"].ToString()
                                        ,RutaFotoValor = item["RutaFotoValor"].ToString()};
                                        f.lstValores = new List<ValorFiltro>();
                                    f.lstValores.Add(v);
                                    lstProducto.Where(c => c.Id == item["Id"].ToString()).FirstOrDefault().lstFiltros.Add(f);
                                    }
                                    
                                }
                            }
                            else {
                            MProducto p = new MProducto()
                                {
                                Id = item["Id"].ToString()
                               ,Nombre = item["Nombre"].ToString()
                               ,Descripcion = item["Descripcion"].ToString()
                               ,RutaFoto = item["RutaFoto"].ToString()
                               ,Precio= item["Precio"].ToString()
                               ,Iva = item["Iva"].ToString()
                               ,PrecioConIva = item["PrecioConIva"].ToString()
                               ,PrecioMayoreo = item["PrecioMayoreo"].ToString()
                               ,CantidadMinMayoreo = item["CantidadMinMayoreo"].ToString()
                               ,FechaInicio = item["FechaInicio"].ToString()
                               ,FechaFin = item["FechaFin"].ToString()
                               ,IdProdCampania = item["IdProdCampania"].ToString()
                               ,IdProdCatSubcategoria = item["IdProdCatSubcategoria"].ToString()
                               ,FolioProducto = item["FolioProducto"].ToString()
                               ,IdPCatProveedor = item["IdPCatProveedor"].ToString()
                               ,Descuento = item["Descuento"].ToString()
                               ,Caduca = item["Caduca"].ToString()
                               ,NombreComercial = item["NombreComercial"].ToString()
                               ,RutaFotoLogo = item["RutaFotoLogo"].ToString()
                               ,IdCategoria = item["IdCategoria"].ToString()
                               ,Categoria = item["Categoria"].ToString()
                               ,IdSubcategoria = item["IdCatSubcategoria"].ToString()
                               ,Subcategoria = item["Subcategoria"].ToString()                               
                                };
                               Filtro f = new Filtro()
                                {
                                    IdFiltro = item["IdFiltro"].ToString()
                                    ,NombreFiltro = item["TituloFiltro"].ToString()                                    
                                    
                                };
                                ValorFiltro v = new ValorFiltro() {
                                    IdValor = item["IdValor"].ToString()
                                    ,NombreValor = item["NombreValor"].ToString()
                                    ,Valor = item["ValorFiltro"].ToString()
                                    ,RutaFotoValor = item["RutaFotoValor"].ToString()
                                };
                                f.lstValores = new List<ValorFiltro>();
                                f.lstValores.Add(v);
                                p.lstFiltros = new List<Filtro>();
                                p.lstFiltros.Add(f);
                                lstProducto.Add(p);
                            }
                            
                        }
                        
                        DataTable ok = lstProducto.toDataTable();
                        respuesta.Objeto = Newtonsoft.Json.JsonConvert.SerializeObject(lstProducto);
                    }
                    //respuesta.Objeto = Newtonsoft.Json.JsonConvert.SerializeObject(dsResult.Tables[0]);
                }
                else {
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


        internal static Respuesta GetProductosLike(string value)
        {
           Respuesta respuesta = new Respuesta();
            try
            {
                DataSet dsResult;
                List<MProducto> lstProducto = new List<MProducto>();
                dsResult = HelperSql.ObtieneDataSet("[SP_OBTENER_PRODUCTOS_LIKE]", value);
                if (dsResult.Tables[0].Rows.Count > 0)
                {                    
                    respuesta.Ok = "SI";
                    respuesta.Mensaje = "Resultados Match";
                    DataTable dt = dsResult.Tables[0];                    
                    if (dt.Rows.Count > 0) {
                        foreach (DataRow item in dt.Rows)
                        {
                            lstProducto.Add(                                
                              new MProducto(){
                               Id = item["Id"].ToString()
                               ,Nombre = item["Nombre"].ToString()
                               ,Descripcion = item["Descripcion"].ToString()
                               ,RutaFoto = item["RutaFoto"].ToString()
                               ,Precio= item["Precio"].ToString()
                               ,Iva = item["Iva"].ToString()
                               ,PrecioConIva = item["PrecioConIva"].ToString()
                               ,PrecioMayoreo = item["PrecioMayoreo"].ToString()
                               ,CantidadMinMayoreo = item["CantidadMinMayoreo"].ToString()
                               ,FechaInicio = item["FechaInicio"].ToString()
                               ,FechaFin = item["FechaFin"].ToString()
                               ,IdProdCampania = item["IdProdCampania"].ToString()
                               ,IdProdCatSubcategoria = item["IdProdCatSubcategoria"].ToString()
                               ,FolioProducto = item["FolioProducto"].ToString()
                               ,IdPCatProveedor = item["IdPCatProveedor"].ToString()
                               ,Descuento = item["Descuento"].ToString()
                               ,Caduca = item["Caduca"].ToString()
                               ,NombreComercial = item["NombreComercial"].ToString()
                               ,RutaFotoLogo = item["RutaFotoLogo"].ToString()
                               ,IdCategoria = item["IdCategoria"].ToString()
                               ,Categoria = item["Categoria"].ToString()
                               ,IdSubcategoria = item["IdCatSubcategoria"].ToString()
                               ,Subcategoria = item["Subcategoria"].ToString()
                            });
                        }
                        respuesta.Objeto = Newtonsoft.Json.JsonConvert.SerializeObject(lstProducto);
                    }
                    //respuesta.Objeto = Newtonsoft.Json.JsonConvert.SerializeObject(dsResult.Tables[0]);
                }
                else {
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

        
    }
}
