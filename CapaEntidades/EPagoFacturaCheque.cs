using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EPagoFacturaCheque : EPagoFactura
    {
        public string NroCheque { get; set; }
        public EBanco Banco { get; set; }
        public DateTime? FechaCheque { get; set; }

        public EPagoFacturaCheque()
        {
                
        }
    }
}
