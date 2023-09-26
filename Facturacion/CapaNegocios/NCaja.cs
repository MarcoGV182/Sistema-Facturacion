using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using CapaDatos;
using System.Windows.Forms;
using System.IO.Pipes;
using CapaEntidades;

namespace CapaNegocio
{
    public class NCaja
    {
       public static string InsertarCaja(ECaja ArqueoCaja) 
       {            
            return new DCaja().InsertarCaja(ArqueoCaja);
       }

       public static string EliminarArqueo(int cajaNro, int usuarioNro)
        {
            DCaja Obj = new DCaja();          
            return Obj.EliminarArqueo(cajaNro, usuarioNro);
        }

        public static string CerrarCaja(ECaja CierreArqueoCaja)
        {
            DCaja Obj = new DCaja();                 
            return Obj.CerrarCaja(CierreArqueoCaja);
        }

        public static DataTable MostrarSaldo() 
       {
            DCaja obj = new DCaja();
            return obj.MostrarSaldoCaja();
       }

        public static DataTable MostrarMovimientoPagosCaja(string fechainicio,string fechafin)
        {
            DCaja obj = new DCaja();
            return obj.MostrarMovimientoPagos(fechainicio,fechafin);
        }

        public static DataTable MostrarListaArqueo(string fechaDesde, string fechaHasta)
        {
            DCaja obj = new DCaja();
            return obj.MostrarListaArqueos(fechaDesde, fechaHasta);
        }

        public static DataTable BuscarMovimientoPagosCaja(string fechainicio, string fechafin)
        {
            DCaja obj = new DCaja();
            return obj.BuscarMovimientoPagos(fechainicio, fechafin);
        }

        public static DataTable FitroResumenCaja(string fechainicio, string fechafin)
        {
            DCaja obj = new DCaja();
            return obj.FiltroCajaResumen(fechainicio, fechafin);
        }

        public static DataTable MostrarCajaAbierta(int usuario)
       {
            DCaja obj = new DCaja();
            return obj.MostrarCajaAbierta(usuario);

       }
         
        public static DataTable ReporteMovimientoCaja(int nroCaja) 
        {
            DataTable dt = new DataTable();
            return dt;
        }

    }
}
