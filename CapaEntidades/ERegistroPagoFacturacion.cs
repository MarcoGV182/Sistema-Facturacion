using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ERegistroPagoFacturacion
    {
        public EPagoFacturaEfectivo Efectivo { get; set; }
        public EPagoFacturaTarjeta Tarjeta { get; set; }
        public EPagoFacturaCheque Cheque { get; set; }
        public EPagoFacturaOtros Otro { get; set; }
    }
}
