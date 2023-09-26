using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ETimbrado
    {
        public int IdTimbrado { get; set; }
        public string NroTimbrado { get; set; }
        public string FechaInicioVigencia { get; set; }
        public string FechaFinVigencia { get; set; }
        public string Ind_Autoimprenta { get; set; }
        public string Estado { get; set; }
    }
}
