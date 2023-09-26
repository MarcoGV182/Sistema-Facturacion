using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
using CapaEntidades;

namespace CapaNegocio
{
    public class NServicio
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(EServicio servicio)
        {
            DServicio objServicio = new DServicio();
            return objServicio.InsertarServicio(servicio);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(EServicio servicio)
        {
            DServicio objServicio = new DServicio();           
            return objServicio.EditarServicio(servicio);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int servicionro)
        {
            DServicio objServicio = new DServicio();
            return objServicio.EliminarServicio(servicionro);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static List<EServicio> Mostrar()
        {
            List<EServicio> ListaServicio = new List<EServicio>();
            try
            {
                var ServicioDT = new DServicio().MostrarServicio();
                foreach (DataRow row in ServicioDT.Rows)
                {
                    EServicio eServicio = new EServicio();
                    eServicio.ArticuloNro = Convert.ToInt32(row[0]);
                    eServicio.Descripcion = row[1].ToString();
                    eServicio.Precio = Convert.ToDouble(row[2]);
                    eServicio.TipoServicioNro = Convert.ToInt32(row[3]);
                    eServicio.TipoServicio = new ETipoServicio()
                    {
                        TipoServicioNro = eServicio.TipoServicioNro,
                        Descripcion = row[4].ToString()
                    };
                    eServicio.TipoImpuestoNro = Convert.ToInt32(row[5]);
                    eServicio.TipoImpuesto = new ETipoImpuesto()
                    {
                        TipoImpuestoNro = eServicio.TipoImpuestoNro,
                        Descripcion = row[6].ToString(),
                        PorcentajeIva = Convert.ToDecimal(row[7]),
                        BaseImponible = Convert.ToDecimal(row[8]),
                    };
                    eServicio.Estado = row[9].ToString();
                    eServicio.Observacion = row[10].ToString();
                    eServicio.FechaRegistro = Convert.ToDateTime(row[11]);

                    ListaServicio.Add(eServicio);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return ListaServicio;
        }

        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static List<EServicio> BuscarServicio(string textoBuscar)
        {
            List<EServicio> ListaServicio = new List<EServicio>();
            try
            {
                var ServicioDT = new DServicio().BuscarServicio(textoBuscar);
                foreach (DataRow row in ServicioDT.Rows)
                {
                    EServicio eServicio = new EServicio();
                    eServicio.ArticuloNro = Convert.ToInt32(row[0]);
                    eServicio.Descripcion = row[1].ToString();
                    eServicio.Precio = Convert.ToDouble(row[2]);
                    eServicio.TipoServicioNro = Convert.ToInt32(row[3]);
                    eServicio.TipoServicio = new ETipoServicio()
                    {
                        TipoServicioNro = eServicio.TipoServicioNro,
                        Descripcion = row[4].ToString()
                    };
                    eServicio.TipoImpuestoNro = Convert.ToInt32(row[5]);
                    eServicio.TipoImpuesto = new ETipoImpuesto()
                    {
                        TipoImpuestoNro = eServicio.TipoImpuestoNro,
                        Descripcion = row[6].ToString(),
                        PorcentajeIva = Convert.ToDecimal(row[7]),
                        BaseImponible = Convert.ToDecimal(row[8]),
                    };
                    eServicio.Estado = row[9].ToString();
                    eServicio.Observacion = row[10].ToString();
                    eServicio.FechaRegistro = Convert.ToDateTime(row[11]);

                    ListaServicio.Add(eServicio);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return ListaServicio;            
        }
    }
}
