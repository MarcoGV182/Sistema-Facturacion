using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Reporting
{
    public class EDetalleInformeVentaColaborador
    {
        public int NroVenta { get; set; }
        public string NroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public int ColaboradorId { get; set; }
        public string NombreColaborador { get; set; }
        public string DocumentoColaborador { get; set; }
        public double TotalVenta { get; set; }
        public int CantidadItems { get; set; }       
    }
}
