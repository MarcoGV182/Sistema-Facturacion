using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class NPagoFactura
    {
       public static string PagoEfectivo(EPagoFacturaEfectivo pagoefectivo) 
       {
            DPagoFacturaEfectivo obj = new DPagoFacturaEfectivo();
            return obj.InsertarPagoFacturaEfectivo(pagoefectivo);       
       }


        public static string PagoTarjeta(EPagoFacturaTarjeta pagoTarjeta)
        {
            DPagoFacturaTarjeta obj = new DPagoFacturaTarjeta();
            return obj.InsertarPagoFacturaTarjeta(pagoTarjeta);
        }

        public static string PagoCheque(EPagoFacturaCheque pagocheque)
        {
            DPagoFacturaCheque obj = new DPagoFacturaCheque();            
            return obj.InsertarPagoFacturaCheque(pagocheque);
        }


        public static string ModificarPago(int nroVenta, ERegistroPagoFacturacion pagos)
        {
            DRegistroPagoFacturacion obj = new DRegistroPagoFacturacion();
            return obj.EditarPagos(nroVenta, pagos);
        }
    }
}
