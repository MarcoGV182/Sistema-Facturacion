using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using CapaEntidades;
using System.Net.Http.Headers;
using System.Net;

namespace CapaNegocio
{
   public class NProducto
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(EProducto producto)
        {
            DProducto objProducto = new DProducto();            
            return objProducto.InsertarProducto(producto);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(EProducto producto)
        {
            DProducto objProducto = new DProducto();            
            return objProducto.EditarProducto(producto);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int productonro)
        {
            DProducto objProducto = new DProducto();
            return objProducto.EliminarProducto(productonro);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static List<EProducto> Mostrar()
        {
            List<EProducto> ListaProductos = new List<EProducto>();
            try
            {
                var ProductoDT = new DProducto().MostrarProducto();
                foreach (DataRow row in ProductoDT.Rows)
                {
                    EProducto eProducto = new EProducto();
                    eProducto.ArticuloNro = Convert.ToInt32(row[0]);
                    eProducto.CodigoBarra = row[1].ToString();
                    eProducto.Descripcion = row[2].ToString();

                    eProducto.TipoProducto = new ETipoProducto()
                    {
                        Descripcion = row[3].ToString()
                    };

                    eProducto.Presentacion = new EPresentacionProducto()
                    {   
                        Descripcion = row[4].ToString()
                    };

                    eProducto.UnidadMedida = new EUnidadMedida() 
                    { 
                        UnidadMedidaNro = Convert.ToInt32(row[5]),
                        Descripcion = row[6].ToString()
                    };

                    eProducto.Marca = new EMarca()
                    {
                        Descripcion = row[7].ToString()
                    };
                    eProducto.FechaVencimiento = row[8] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[8]);
                    eProducto.TipoImpuesto = new ETipoImpuesto()
                    {
                        Descripcion = row[9].ToString(),
                        TipoImpuestoNro = Convert.ToInt32(row[10]),
                        PorcentajeIva = Convert.ToDecimal(row[11]),
                        BaseImponible = Convert.ToDecimal(row[12])
                    };
                    eProducto.Stockminimo = Convert.ToInt32(row[13]);
                    eProducto.StockActual = Convert.ToInt32(row[14]);
                    eProducto.PrecioCompra = Convert.ToInt32(row[15]);
                    eProducto.Precio = Convert.ToDouble(row[16]);
                    eProducto.Estado = row[17].ToString();
                    eProducto.Observacion = row[18].ToString();

                    ListaProductos.Add(eProducto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaProductos;
        }

        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static List<EProducto> MostrarActivo()
        {  
            List<EProducto> ListaProductos = new List<EProducto>();
            try
            {
                var ProductoDT = new DProducto().MostrarProductoActivo();
                foreach (DataRow row in ProductoDT.Rows)
                {
                    EProducto eProducto = new EProducto();
                    eProducto.ArticuloNro = Convert.ToInt32(row[0]);
                    eProducto.CodigoBarra = row[1].ToString();
                    eProducto.Descripcion = row[2].ToString();

                    eProducto.TipoProducto = new ETipoProducto()
                    {
                        Descripcion = row[3].ToString()
                    };

                    eProducto.Presentacion = new EPresentacionProducto()
                    {
                        Descripcion = row[4].ToString()
                    };

                    eProducto.UnidadMedida = new EUnidadMedida()
                    {
                        UnidadMedidaNro = Convert.ToInt32(row[5]),
                        Descripcion = row[6].ToString()
                    };

                    eProducto.Marca = new EMarca()
                    {
                        Descripcion = row[7].ToString()
                    };
                    eProducto.FechaVencimiento = row[8] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[8]);
                    eProducto.TipoImpuesto = new ETipoImpuesto()
                    {
                        Descripcion = row[9].ToString(),
                        TipoImpuestoNro = Convert.ToInt32(row[10]),
                        PorcentajeIva = Convert.ToDecimal(row[11]),
                        BaseImponible = Convert.ToDecimal(row[12])
                    };
                    eProducto.Stockminimo = Convert.ToInt32(row[13]);
                    eProducto.StockActual = Convert.ToInt32(row[14]);
                    eProducto.PrecioCompra = Convert.ToDouble(row[15]);
                    eProducto.Precio = Convert.ToDouble(row[16]);
                    eProducto.Estado = row[17].ToString();
                    eProducto.Observacion = row[18].ToString();

                    ListaProductos.Add(eProducto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaProductos;
        }

        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static List<EProducto> BuscarProducto(string textoBuscar)
        {
            List<EProducto> ListaProductos = new List<EProducto>();
            try
            {
                var ProductoDT = new DProducto().BuscarProducto(textoBuscar);
                foreach (DataRow row in ProductoDT.Rows)
                {
                    EProducto eProducto = new EProducto();
                    eProducto.ArticuloNro = Convert.ToInt32(row[0]);
                    eProducto.CodigoBarra = row[1].ToString();
                    eProducto.Descripcion = row[2].ToString();

                    eProducto.TipoProducto = new ETipoProducto()
                    {
                        Descripcion = row[3].ToString()
                    };

                    eProducto.Presentacion = new EPresentacionProducto()
                    {
                        Descripcion = row[4].ToString()
                    };

                    eProducto.UnidadMedida = new EUnidadMedida()
                    {
                        UnidadMedidaNro = Convert.ToInt32(row[5]),
                        Descripcion = row[6].ToString()
                    };

                    eProducto.Marca = new EMarca()
                    {
                        Descripcion = row[7].ToString()
                    };
                    eProducto.FechaVencimiento = row[8] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[8]);
                    eProducto.TipoImpuesto = new ETipoImpuesto()
                    {
                        Descripcion = row[9].ToString(),
                        TipoImpuestoNro = Convert.ToInt32(row[10]),
                        PorcentajeIva = Convert.ToDecimal(row[11]),
                        BaseImponible = Convert.ToDecimal(row[12])
                    };
                    eProducto.Stockminimo = Convert.ToInt32(row[13]);
                    eProducto.StockActual = Convert.ToInt32(row[14]);
                    eProducto.PrecioCompra = Convert.ToDouble(row[15]);
                    eProducto.Precio = Convert.ToDouble(row[16]);
                    eProducto.Estado = row[17].ToString();
                    eProducto.Observacion = row[18].ToString();

                    ListaProductos.Add(eProducto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaProductos;
        }


        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static List<EProducto> BuscarProductoActivo(string textoBuscar)
        {
            List<EProducto> ListaProductos = new List<EProducto>();
            try
            {
                var ProductoDT = new DProducto().BuscarProductoActivo(textoBuscar);
                foreach (DataRow row in ProductoDT.Rows)
                {
                    EProducto eProducto = new EProducto();
                    eProducto.ArticuloNro = Convert.ToInt32(row[0]);
                    eProducto.CodigoBarra = row[1].ToString();
                    eProducto.Descripcion = row[2].ToString();

                    eProducto.TipoProducto = new ETipoProducto()
                    {
                        Descripcion = row[3].ToString()
                    };

                    eProducto.Presentacion = new EPresentacionProducto()
                    {
                        Descripcion = row[4].ToString()
                    };

                    eProducto.UnidadMedida = new EUnidadMedida()
                    {
                        UnidadMedidaNro = Convert.ToInt32(row[5]),
                        Descripcion = row[6].ToString()
                    };

                    eProducto.Marca = new EMarca()
                    {
                        Descripcion = row[7].ToString()
                    };
                    eProducto.FechaVencimiento = row[8] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[8]);


                    eProducto.TipoImpuesto = new ETipoImpuesto()
                    {
                        Descripcion = row[9].ToString(),
                        TipoImpuestoNro = Convert.ToInt32(row[10]),
                        PorcentajeIva = Convert.ToDecimal(row[11]),
                        BaseImponible = Convert.ToDecimal(row[12])
                    };
                    eProducto.Stockminimo = Convert.ToInt32(row[13]);
                    eProducto.StockActual = Convert.ToInt32(row[14]);
                    eProducto.PrecioCompra = Convert.ToDouble(row[15]);
                    eProducto.Precio = Convert.ToDouble(row[16]);
                    eProducto.Estado = row[17].ToString();
                    eProducto.Observacion = row[18].ToString();

                    ListaProductos.Add(eProducto);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaProductos;
        }
    }
}
