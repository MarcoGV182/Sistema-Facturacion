using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CapaEntidades;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NFactura
    {
       
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(EFactura CabFactura,DataTable dtDetalleFactura)
        {
            DFactura objFactura = new DFactura();         
            //DETALLES DE COMPRAS
            List<EDetalleFactura> detalles = new List<EDetalleFactura>();
            foreach (DataRow row in dtDetalleFactura.Rows)
            {
                EDetalleFactura dtFactura = new EDetalleFactura();                
                dtFactura.Articulo.ArticuloNro = Convert.ToInt32(row["ItemNro"].ToString());
                dtFactura.NroItem = Convert.ToInt32(row["Nro"]);
                dtFactura.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                dtFactura.Precio = Convert.ToInt64(row["Precio"]);
                dtFactura.PrecioFinal = Convert.ToInt64(row["PrecioFinal"]);
                ETipoImpuesto ti = new ETipoImpuesto()
                {
                    TipoImpuestoNro = Convert.ToInt32(row["CodTipoImpuesto"])
                };
                dtFactura.TipoImpuesto = ti;
                detalles.Add(dtFactura);
            }
            return objFactura.InsertarFactura(CabFactura, detalles);
        }


        public static string Insertar(EFactura CabFactura, List<EDetalleFactura> dtDetalleFactura, ERegistroPagoFacturacion pagos)
        {
            DFactura objFactura = new DFactura();
            List<EDetalleFactura> detalles = new List<EDetalleFactura>();
            string respuesta = "OK";
            try
            {
                double totalFactura = dtDetalleFactura.Sum(c=>c.PrecioFinal * c.Cantidad);   
                respuesta = ValidacionPagos(totalFactura, pagos);
                if (!respuesta.Equals("OK"))
                    throw new Exception(respuesta);
            }
            catch (Exception ex)
            {
                throw ex;
            }    
           
            return objFactura.RegistrarFacturacion(CabFactura, dtDetalleFactura, pagos);
        }


        private static string ValidacionPagos(double totalVenta,ERegistroPagoFacturacion pagos) 
        {
            string val = "OK";
            if (pagos != null)
            {
                double importeEfectivo = pagos.Efectivo == null ? 0 : (pagos.Efectivo.Monto - pagos.Efectivo.Vuelto);
                double importeTarjeta = pagos.Tarjeta == null ? 0 : pagos.Tarjeta.Monto;
                double importeCheque = pagos.Cheque == null ? 0 : pagos.Cheque.Monto;
                double importeOtros = pagos.Otro == null ? 0 : pagos.Otro.Monto;
                double totalPagado = importeEfectivo + importeTarjeta + importeCheque + importeOtros;


                if (totalPagado < totalVenta)
                {
                    val = "El monto de pago ingresado es menor al monto total";
                    return val;
                }


                if ((importeTarjeta > totalVenta) ||
                    (importeCheque > totalVenta) ||
                    (importeOtros > totalVenta))
                {
                    val = "El monto de pago diferente a Efectivo no puede ser mayor al monto total";
                    return val;
                }

                if (totalPagado > totalVenta)
                {
                    val = "El monto de pago diferente a Efectivo no puede ser mayor al monto total";
                    return val;
                }
            }

            return val;
        }


        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string AnularFactura(int nroVenta,int usuario)
        {
            DFactura objFactura = new DFactura();
            return objFactura.Anular(nroVenta, usuario);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static List<EFactura> Mostrar()
        {
            List<EFactura> ListaFacturas = new List<EFactura>();
            try
            {
                var FacturaDT = new DFactura().MostrarFactura();
                foreach (DataRow row in FacturaDT.Rows)
                {
                    EFactura Factura = new EFactura();
                    Factura.Id = Convert.ToInt32(row[0]);
                    Factura.NroFactura = row[1].ToString();
                    Factura.Cliente = new ECliente()
                    { 
                        PersonaNro = Convert.ToInt32(row[2]),
                        Documento = row[3].ToString(),
                        Nombre = row[4].ToString()
                    };

                    if (row[5] != DBNull.Value)
                    {
                        Factura.ColaboradorVendedor = new EColaborador()
                        {
                            PersonaNro = Convert.ToInt32(row[5]),
                            Nombre = row[6].ToString()
                        };
                    }
                    
                    Factura.Fecha = Convert.ToDateTime(row[7]);
                    Factura.TipoPago = new ETipoPago()
                    {
                        IdFormaPago = Convert.ToInt32(row[8]),
                        Descripcion = row[9].ToString()
                    };
                    Factura.TipoComprobante = new ETipoComprobante()
                    {
                        ComprobanteNro = Convert.ToInt32(row[10]),
                        Nombre = row[11].ToString()
                    };
                    Factura.ImporteIVA = Convert.ToDouble(row[12]);
                    Factura.ImporteGravada = Convert.ToDouble(row[13]);
                    Factura.ImporteExento = Convert.ToDouble(row[14]);
                    Factura.Observacion = row["Observacion"].ToString();
                    Factura.Ind_Autoimprenta = row["Ind_Autoimprenta"].ToString();
                    Factura.UsuarioInsercion = row["UsuarioInsercion"].ToString();
                    Factura.FechaInsercion = Convert.ToDateTime(row["FechaInsercion"]);
                    Factura.Estado = row["Estado"].ToString();
                    Factura.FechaAnulacion = row["FechaAnulacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["FechaAnulacion"]);
                    Factura.UsuarioAnulacion = row["UsuarioAnulacion"].ToString();

                    ListaFacturas.Add(Factura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaFacturas;
        }

        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable MostrarAnulada()
        {
            return new DFactura().MostrarFacturaAnulada();
        }
        

        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static List<EFactura> BuscarFacturaFecha(string textoBuscar1, string textoBuscar2)
        {
            List<EFactura> ListaFacturas = new List<EFactura>();
            try
            {
                var FacturaDT = new DFactura().BuscarFechas(textoBuscar1, textoBuscar2);
                foreach (DataRow row in FacturaDT.Rows)
                {
                    EFactura Factura = new EFactura();
                    Factura.Id = Convert.ToInt32(row[0]);
                    Factura.NroFactura = row[1].ToString();
                    Factura.Cliente = new ECliente()
                    {
                        PersonaNro = Convert.ToInt32(row[2]),
                        Documento = row[3].ToString(),
                        Nombre = row[4].ToString()
                    };

                    if (row[5] != DBNull.Value)
                    {
                        Factura.ColaboradorVendedor = new EColaborador()
                        {
                            PersonaNro = Convert.ToInt32(row[5]),
                            Nombre = row[6].ToString()
                        };
                    }

                    Factura.Fecha = Convert.ToDateTime(row[7]);
                    Factura.TipoPago = new ETipoPago()
                    {
                        IdFormaPago = Convert.ToInt32(row[8]),
                        Descripcion = row[9].ToString()
                    };
                    Factura.TipoComprobante = new ETipoComprobante()
                    {
                        ComprobanteNro = Convert.ToInt32(row[10]),
                        Nombre = row[11].ToString()
                    };
                    Factura.ImporteIVA = Convert.ToDouble(row[12]);
                    Factura.ImporteGravada = Convert.ToDouble(row[13]);
                    Factura.ImporteExento = Convert.ToDouble(row[14]);
                    Factura.Observacion = row["Observacion"].ToString();
                    Factura.Ind_Autoimprenta = row["Ind_Autoimprenta"].ToString();
                    Factura.UsuarioInsercion = row["UsuarioInsercion"].ToString();
                    Factura.FechaInsercion = Convert.ToDateTime(row["FechaInsercion"]);
                    Factura.Estado = row["Estado"].ToString();
                    Factura.FechaAnulacion = row["FechaAnulacion"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["FechaAnulacion"]);
                    Factura.UsuarioAnulacion = row["UsuarioAnulacion"].ToString();

                    ListaFacturas.Add(Factura);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaFacturas;
        }

        public static DataTable MostrarDetalle(int idVenta)
        {
            DFactura objFactura = new DFactura();
            return objFactura.MostrarDetalleFactura(idVenta);
        }


        public static string CuentaACobrar(string nrofactura, int cliente)
        {
            EFactura objFactura = new EFactura();
            objFactura.NroFactura = nrofactura;
            objFactura.Cliente = new ECliente() 
            { 
                PersonaNro = cliente
            };
            return new DFactura().CuentaACobrar(objFactura);
        }



        public static string ConfirmacionInsercion(int nroVenta)
        {
            DFactura objFactura = new DFactura();            
            return objFactura.ConfInsercion(nroVenta);
        }


        //PRUEBA DE NUMERACION DE FACTURA
        public static DataTable MostrarNumeracion(string comprobante,string indAutoimprenta)
        {
            DFactura objFactura = new DFactura();
            return objFactura.MostrarNumeracionFactura(comprobante, indAutoimprenta);
        }


        public static DataSet MostrarPagoFactura(int nroVenta) 
        {
            EFactura objFactura = new EFactura();
            objFactura.Id = nroVenta;
            return new DFactura().MostrarPagosFactura(objFactura);
        
        }



        public static double DesglosarImportesIVA(double importeIVAIncluido, int TipoImpuesto, int cantidadDecimales, string valorARetornar)
        {
            DFactura objFactura = new DFactura();
            return objFactura.DesglosarIVA(importeIVAIncluido,TipoImpuesto,cantidadDecimales,valorARetornar);

        }


    }
}
