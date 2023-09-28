using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaEntidades.Reporting
{
    public class ELibroVentaReport
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }        
        public DateTime FechaReport { get; set; }
        public double TotalGravada { get; set; }
        public double TotalIVA { get; set; }
        public double TotalExento { get; set; }
        public double TotalGral { get; set; }
        public List<EDetalleDeVentas> DetallesVentas { get; set; }
    }
}
