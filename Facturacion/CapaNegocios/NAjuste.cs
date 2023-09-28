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
    public class NAjuste
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(EAjuste ajusteCabecera,DataTable dtDetalleAjuste)
        {            
            //DETALLES DE AJUSTES
            List<EDetalleAjuste> detalles = new List<EDetalleAjuste>();
            foreach (DataRow row in dtDetalleAjuste.Rows)
            {
                EDetalleAjuste dtajuste = new EDetalleAjuste();
                dtajuste.ArticuloNro = Convert.ToInt32(row["ArticuloNro"].ToString());                
                dtajuste.Costo= Convert.ToDouble(row["Precio"].ToString());
                dtajuste.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                dtajuste.StockAnterior = Convert.ToInt32(row["StockAnterior"].ToString());
                detalles.Add(dtajuste);
            }
            return new DAjuste().InsertarAjuste(ajusteCabecera, detalles);
        }



        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DAjuste().MostrarAjuste();
        }

        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static DataTable BuscarAjusteFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            DAjuste objAjuste = new DAjuste();
            return objAjuste.BuscarFechas(FechaDesde, FechaHasta);
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
            return obj.EliminarAjusteRestaurar(codAjuste);
        }


        public static string Restaurar(int codAjuste)
        {
            DAjuste obj = new DAjuste();
            return obj.RestaurarStock(codAjuste);
        }


    }
}
