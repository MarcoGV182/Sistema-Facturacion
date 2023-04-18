using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCompra
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(DCompra compra, DataTable dtDetalleCompra)
        {
            DCompra objCompra = new DCompra();            
            //DETALLES DE COMPRAS
            List<DDetalleIngreso> detalles = new List<DDetalleIngreso>();
            foreach(DataRow row in dtDetalleCompra.Rows) {
                DDetalleIngreso dtcompra = new DDetalleIngreso();
               // dtcompra.NroFacturaCompra = row["NroFactura"].ToString();
                //dtcompra.ProveedorNro = Convert.ToInt32(row["ProveedorNro"].ToString());
                dtcompra.ProductoNro = Convert.ToInt32(row["ProductoNro"].ToString());  
                dtcompra.NroItem = Convert.ToInt32(row["Nro"].ToString());
                DTipoImpuesto ti = new DTipoImpuesto()
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
            objCompra.Id = NroCompra;
            return objCompra.EliminarCompra(objCompra);
        }



        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string CuentaAPagar(int NroCompra)
        {
            DCompra objCompra = new DCompra();
            objCompra.Id = NroCompra;
            return objCompra.CuentaAPagar(objCompra);
        }


        //Metodo para restaurar el stock al elimiar una compra
        public static string Restaurar(int NroCompra) 
        {
            DCompra objCompra = new DCompra();
            objCompra.Id = NroCompra;
            return objCompra.RestaurarStock(objCompra);
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
