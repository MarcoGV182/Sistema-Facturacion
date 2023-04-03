using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DTimbrado
    {
        public int IdTimbrado { get; set; }
        public string NroTimbrado { get; set; }
        public string FechaInicioVigencia { get; set; }
        public string FechaFinVigencia { get; set; }
        public string Estado { get; set; }
    }
}
