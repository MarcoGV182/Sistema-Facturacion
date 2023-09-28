using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Reporting
{
    public class EDetalleDeVentas
    {
        public int NroVenta { get; set; }
        public DateTime Fecha { get; set; }
        public string NroFactura { get; set; }
        public string Comprobante { get; set; }
        public string Cliente { get; set; }
        public string TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public double Imp_Gravado { get; set; }
        public double Imp_IVA { get; set; }
        public double Imp_Exento { get; set; }
        public double Total { get; set; }
    }
}
