using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.ReportClass
{
    public class NMovimientoReport
    {
        public string NroDocumento { get; set; }
        public DateTime Fecha { get; set; }
        public string Concepto { get; set; }
        public string FormaPago { get; set; }
        public double Ingreso { get; set; }
        public double Egreso { get; set; }
    }
}
