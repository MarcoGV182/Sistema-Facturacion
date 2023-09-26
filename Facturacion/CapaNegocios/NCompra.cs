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
    public class NCompra
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(ECompra compra, DataTable dtDetalleCompra)
        {
            DCompra objCompra = new DCompra();            
            //DETALLES DE COMPRAS
            List<EDetalleCompra> detalles = new List<EDetalleCompra>();
            foreach(DataRow row in dtDetalleCompra.Rows) {
                EDetalleCompra dtcompra = new EDetalleCompra();
               // dtcompra.NroFacturaCompra = row["NroFactura"].ToString();
                //dtcompra.ProveedorNro = Convert.ToInt32(row["ProveedorNro"].ToString());
                dtcompra.ProductoNro = Convert.ToInt32(row["ProductoNro"].ToString());  
                dtcompra.NroItem = Convert.ToInt32(row["Nro"].ToString());
                ETipoImpuesto ti = new ETipoImpuesto()
                {
                    TipoImpuestoNro = Convert.ToInt32(row["CodTipoImpuesto"])
                };
                dtcompra.TipoImpuesto = ti;
                dtcompra.Cantidad= Convert.ToInt32(row["Cantidad"].ToString());
                dtcompra.PrecioUnitario= Convert.ToDecimal(row["Precio"].ToString());
                detalles.Add(dtcompra);
            }
            compra.DetalleCompra = detalles;

            return objCompra.Insertar(compra);
        }


        //Metodo para anular que llama al metodo eliminar de la capa Datos
        public static string AnularCompra(int NroCompra, int usuario)
        {
            DCompra objCompra = new DCompra();           
            return objCompra.Anular(NroCompra,usuario);
        }


        //Metodo para anular que llama al metodo eliminar de la capa Datos
        public static string EliminarCompra(int NroCompra)
        {
            DCompra objCompra = new DCompra();
            return objCompra.EliminarCompra(NroCompra);
        }



        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string CuentaAPagar(int NroCompra)
        {
            DCompra objCompra = new DCompra();           
            return objCompra.CuentaAPagar(NroCompra);
        }


        //Metodo para restaurar el stock al elimiar una compra
        public static string Restaurar(int NroCompra) 
        {
            DCompra objCompra = new DCompra();
            return objCompra.RestaurarStock(NroCompra);
        }
        

        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DCompra().MostrarCompra();
        }


        //Metodo para mostrar que llama al metodo mostrar facturas anuladas de la capa Datos
        public static DataTable MostrarAnulada()
        {
            return new DCompra().MostrarCompraAnulada();
        }


        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static DataTable BuscarCompraFecha(string textoBuscar1, string textoBuscar2)
        {
            DCompra objCompra = new DCompra();
          
            return objCompra.BuscarFechas(textoBuscar1,textoBuscar2);
        }

        public static DataTable MostarDetalle(int NroCompra)
        {
            DCompra objCompra = new DCompra();
            return objCompra.MostrarDetalleCompra(NroCompra);
        }
    }
}
