using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NPagoFactura
    {
       public static string PagoEfectivo(DPagoFacturaEfectivo pagoefectivo) 
       {
            DPagoFacturaEfectivo obj = new DPagoFacturaEfectivo();
            return obj.InsertarPagoFacturaEfectivo(pagoefectivo);       
       }


        public static string PagoTarjeta(DPagoFacturaTarjeta pagoTarjeta)
        {
            DPagoFacturaTarjeta obj = new DPagoFacturaTarjeta();
            return obj.InsertarPagoFacturaTarjeta(pagoTarjeta);
        }

        public static string PagoCheque(DPagoFacturaCheque pagocheque)
        {
            DPagoFacturaCheque obj = new DPagoFacturaCheque();            
            return obj.InsertarPagoFacturaCheque(pagocheque);
        }


        public static string ModificarPago(int nroVenta, RegistroPagoFacturacion pagos)
        {
            RegistroPagoFacturacion obj = new RegistroPagoFacturacion();
            return obj.EditarPagos(nroVenta, pagos);
        }
    }
}
