using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NFactura
    {
       
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(DFactura CabFactura,DataTable dtDetalleFactura)
        {
            DFactura objFactura = new DFactura();         
            //DETALLES DE COMPRAS
            List<DDetalleFactura> detalles = new List<DDetalleFactura>();
            foreach (DataRow row in dtDetalleFactura.Rows)
            {
                DDetalleFactura dtFactura = new DDetalleFactura();                
                dtFactura.ArticuloNro = Convert.ToInt32(row["ItemNro"].ToString());
                dtFactura.NroItem = Convert.ToInt32(row["Nro"]);
                dtFactura.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                dtFactura.Precio = Convert.ToInt64(row["Precio"]);
                dtFactura.PrecioFinal = Convert.ToInt64(row["PrecioFinal"]);
                DTipoImpuesto ti = new DTipoImpuesto()
                {
                    TipoImpuestoNro = Convert.ToInt32(row["CodTipoImpuesto"])
                };
                dtFactura.TipoImpuesto = ti;
                detalles.Add(dtFactura);
            }
            return objFactura.InsertarFactura(CabFactura, detalles);
        }


        public static string Insertar(DFactura CabFactura, DataTable dtDetalleFactura, RegistroPagoFacturacion pagos)
        {
            DFactura objFactura = new DFactura();
            //DETALLES DE COMPRAS
            List<DDetalleFactura> detalles = new List<DDetalleFactura>();
            foreach (DataRow row in dtDetalleFactura.Rows)
            {
                DDetalleFactura dtFactura = new DDetalleFactura();

                dtFactura.ArticuloNro = Convert.ToInt32(row["ItemNro"].ToString());
                dtFactura.NroItem = Convert.ToInt32(row["Nro"]);
                dtFactura.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                dtFactura.Precio = Convert.ToInt64(row["PrecioInicial"]);
                dtFactura.PrecioFinal = Convert.ToInt64(row["Precio"]);
                DTipoImpuesto ti = new DTipoImpuesto()
                {
                    TipoImpuestoNro = Convert.ToInt32(row["CodTipoImpuesto"])
                };
                dtFactura.TipoImpuesto = ti;
                detalles.Add(dtFactura);
            }
            return objFactura.RegistrarFacturacion(CabFactura, detalles, pagos);
        }


        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string AnularFactura(int nroVenta,string usuario)
        {
            DFactura objFactura = new DFactura();
            return objFactura.Anular(nroVenta, usuario);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DFactura().MostrarFactura();
        }

        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable MostrarAnulada()
        {
            return new DFactura().MostrarFacturaAnulada();
        }
        

        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static DataTable BuscarFacturaFecha(string textoBuscar1, string textoBuscar2)
        {
            DFactura objFactura = new DFactura();

            return objFactura.BuscarFechas(textoBuscar1, textoBuscar2);
        }

        public static DataTable MostrarDetalle(string nrofactura,int clientenro)
        {
            DFactura objFactura = new DFactura();
            return objFactura.MostrarDetalleFactura(nrofactura,clientenro);
        }

        
        public static string CuentaACobrar(string nrofactura, int cliente)
        {
            DFactura objFactura = new DFactura();
            objFactura.NroFactura = nrofactura;
            objFactura.ClienteNro = cliente;
            return objFactura.CuentaACobrar(objFactura);
        }



        public static string ConfirmacionInsercion(int nroVenta)
        {
            DFactura objFactura = new DFactura();            
            return objFactura.ConfInsercion(nroVenta);
        }


        //PRUEBA DE NUMERACION DE FACTURA
        public static DataTable MostrarNumeracion(string comprobante)
        {
            DFactura objFactura = new DFactura();
            return objFactura.MostrarNumeracionFactura(comprobante);
        }


        public static DataTable MostrarPagoFactura(int nroVenta) 
        {
            DFactura objFactura = new DFactura();
            objFactura.Id = nroVenta;
            return objFactura.MostrarPagosFactura(objFactura);
        
        }



        public static Double DesglosarImportesIVA(double importeIVAIncluido, int TipoImpuesto, int cantidadDecimales, string valorARetornar)
        {
            DFactura objFactura = new DFactura();
            return objFactura.DesglosarIVA(importeIVAIncluido,TipoImpuesto,cantidadDecimales,valorARetornar);

        }


    }
}
