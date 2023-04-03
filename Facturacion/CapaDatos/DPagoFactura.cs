using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DPagoFactura
    {
        public int PagoNro { get; set; }
        public int NroVenta { get; set; }
        public double Monto { get; set; }
    }


    public class RegistroPagoFacturacion
    {
        public DPagoFacturaEfectivo Efectivo { get; set; }
        public DPagoFacturaTarjeta Tarjeta { get; set; }
        public DPagoFacturaCheque Cheque { get; set; }
        public DPagoFacturaOtros Otro { get; set; }
    }
    

}
