using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EPagoFacturaOtros : EPagoFactura
    {
        public ETipoPagoOtros TipoPagoOtro { get; set; }
        public string NroDocumentoPago { get; set; }

        public EPagoFacturaOtros()
        {
                
        }
    }
}
