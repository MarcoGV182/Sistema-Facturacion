using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class NCuentaPorCobrar
    {
        public static string InsertarPago(int cuentaporcobrarnro, int cuotanro, DateTime fecha,int formapagonro ,decimal importe, string observacion, int usuario) 
        {
            DPagoCuentaPorCobrar obj = new DPagoCuentaPorCobrar();
            obj.CuentaporCobrarNro = cuentaporcobrarnro;
            obj.Fecha = fecha;
            obj.FormaPagoNro = formapagonro;
            obj.Importe = importe;
            obj.Observacion = observacion;
            obj.UsuarioNro = usuario;

            return obj.InsertarPagoCuentaPorCobrar(obj);
        }


        public static DataTable MostrarFacturas(int clienteNro) 
        {
            DPagoCuentaPorCobrar obj = new DPagoCuentaPorCobrar();
            return obj.MostrarCliente(clienteNro);
        }

        public static DataTable MostrarCuotas(int cuentacobrarnro)
        {
            DPagoCuentaPorCobrar obj = new DPagoCuentaPorCobrar();
            return obj.MostrarCuotasFactura(cuentacobrarnro);
        }


        public static DataTable MostrarHistorico(int clientenro)
        {
            DPagoCuentaPorCobrar obj = new DPagoCuentaPorCobrar();
            return obj.MostrarHistorico(clientenro);
        }


    }
}
