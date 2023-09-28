using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Reporting
{
    public class EInformeCaja
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }       
        public DateTime FechaReport { get; set; }
        public double TotalApertura { get;  set; }
        public double TotalEntrega { get;  set; }
        public double TotalSaldo { get;  set; }
        public double TotalDiferencia { get;  set; }
        public List<ECaja> ListaArqueos { get; set; }
    }
}
