using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NAjuste
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(string descripcion, DateTime fechahora, string estado, string observacion, int tipoajusteNro, string usuario,DataTable dtDetalleAjuste)
        {
            DAjuste objAjuste = new DAjuste();
            objAjuste.Descripcion = descripcion;
            objAjuste.FechaHora = fechahora;
            objAjuste.Estado = estado;
            objAjuste.TipoAjusteNro = tipoajusteNro;
            objAjuste.Observacion = observacion;
            objAjuste.Usuario = usuario;
            //DETALLES DE AJUSTES
            List<DDetalleAjuste> detalles = new List<DDetalleAjuste>();
            foreach (DataRow row in dtDetalleAjuste.Rows)
            {
                DDetalleAjuste dtajuste = new DDetalleAjuste();
                dtajuste.ArticuloNro = Convert.ToInt32(row["ArticuloNro"].ToString());                
                dtajuste.Costo= Convert.ToDouble(row["Precio"].ToString());
                dtajuste.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                dtajuste.StockAnterior = Convert.ToInt32(row["StockAnterior"].ToString());
                detalles.Add(dtajuste);
            }
            return objAjuste.InsertarAjuste(objAjuste, detalles);
        }



        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DAjuste().MostrarAjuste();
        }

        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static DataTable BuscarAjusteFecha(string textoBuscar1, string textoBuscar2)
        {
            DAjuste objAjuste = new DAjuste();

            return objAjuste.BuscarFechas(textoBuscar1, textoBuscar2);
        }

        public static DataTable MostarDetalle(int CodAjuste)
        {
            DAjuste objAjuste = new DAjuste();
            return objAjuste.MostrarDetalleAjuste(CodAjuste);
        }


        public static DataTable MostrarNumeracion()
        {
            return new DAjuste().MostrarNumeracionAjuste();
        }

        public static string Eliminar(int codAjuste) 
        {
            DAjuste obj = new DAjuste();
            obj.CodAjuste = codAjuste;
            return obj.EliminarAjusteRestaurar(obj);
        }


        public static string Restaurar(int codAjuste)
        {
            DAjuste obj = new DAjuste();
            obj.CodAjuste = codAjuste;
            return obj.RestaurarStock(obj);
        }


    }
}
