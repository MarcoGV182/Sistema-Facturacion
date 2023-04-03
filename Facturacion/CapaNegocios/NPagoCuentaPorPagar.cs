using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class NPagoCuentaPorPagar
    {

        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(int CuentaPagar, DateTime fecha,int formapagonro ,decimal importe, string observacion,int usuario)
        {
            DPagoCuentaPorPagar objDeuda = new DPagoCuentaPorPagar();
            objDeuda.CuentaPagarNro = CuentaPagar;
            objDeuda.Fecha = fecha;
            objDeuda.FormaPagoNro = formapagonro;
            objDeuda.Importe = importe;
            objDeuda.Observacion = observacion;
            objDeuda.Usuario = usuario;
           
            return objDeuda.InsertarCuentaxPagar(objDeuda);
        }

        public static string Eliminar(int cuentacobrarnro, int pagonro)
        {
            DPagoCuentaPorPagar obj = new DPagoCuentaPorPagar();
            obj.CuentaPagarNro = cuentacobrarnro;
            obj.PagoNro = pagonro;
            return obj.EliminarPagoCuentaPorPagar(obj);
        }




        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DPagoCuentaPorPagar().MostrarDeuda();
        }

        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static DataTable BuscarDeudaFecha(string textoBuscar1, string textoBuscar2)
        {
            DPagoCuentaPorPagar objDeuda = new DPagoCuentaPorPagar();

            return objDeuda.BuscarFechas(textoBuscar1, textoBuscar2);
        }

        public static DataTable MostarDetalle(string factura, int proveedor)
        {
            DPagoCuentaPorPagar objDeuda = new DPagoCuentaPorPagar();
            return objDeuda.MostrarDetalleDeuda(factura,proveedor);
        }

        public static DataTable MostrarHistorico(int proveedornro)
        {
            DPagoCuentaPorPagar objDeuda = new DPagoCuentaPorPagar();
            return objDeuda.MostrarHistoricoPago(proveedornro);
        }


    }
}
