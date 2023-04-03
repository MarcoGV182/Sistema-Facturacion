using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class NPagoCuentaPorCobrar
    {

        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(int CuentaCobrar, DateTime fecha,int formapagonro ,decimal importe, string observacion,int usuarionro)
        {
            DPagoCuentaPorCobrar objDeuda = new DPagoCuentaPorCobrar();
            objDeuda.CuentaporCobrarNro = CuentaCobrar;
            objDeuda.Fecha = fecha;
            objDeuda.FormaPagoNro = formapagonro;
            objDeuda.Importe = importe;
            objDeuda.Observacion = observacion;
            objDeuda.UsuarioNro = usuarionro;
           
            return objDeuda.InsertarPagoCuentaPorCobrar(objDeuda);
        }


        public static string Eliminar(int cuentacobrarnro, int pagonro) 
        {
            DPagoCuentaPorCobrar obj = new DPagoCuentaPorCobrar();
            obj.CuentaporCobrarNro = cuentacobrarnro;
            obj.PagoNro = pagonro;
            return obj.EliminarPagoCuentaPorCobrar(obj);
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
