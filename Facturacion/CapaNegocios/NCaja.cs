using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using CapaDatos;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NCaja
    {
       public static string InsertarCaja(DateTime fechaApertura, int personaNro, double monto, string observacion) 
       {
            DCaja Obj = new DCaja();
            Obj.FechaApertura = fechaApertura;
            Obj.PersonaNro = personaNro;
            Obj.Observacion = observacion;
            Obj.Monto = monto;
            return Obj.InsertarCaja(Obj);
       }

       public static string EliminarArqueo(int cajaNro, int usuarioNro)
        {
            DCaja Obj = new DCaja();
            Obj.NroCaja = cajaNro;
            Obj.PersonaNro = usuarioNro;
            return Obj.EliminarArqueo(Obj);
        }


        public static string CerrarCaja(int nrocaja,DateTime? fechacierre,double importeentrega, double saldofinal, double diferencia)
        {
            DCaja Obj = new DCaja();
            Obj.NroCaja = nrocaja;
            Obj.FechaCierre = fechacierre;
            Obj.ImporteEntrega = importeentrega;
            Obj.SaldoFinal = saldofinal;
            Obj.Diferencia = diferencia;           
            return Obj.CerrarCaja(Obj);
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
          
    }
}
