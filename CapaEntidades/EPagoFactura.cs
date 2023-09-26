using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EPagoFactura
    {
        public int PagoNro { get; set; }
        public int NroVenta { get; set; }
        public double Monto { get; set; }
    }
}
