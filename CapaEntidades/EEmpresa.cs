using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EEmpresa
    {
        public int EmpresaNro { get; set; }
        public string Nombre { get; set; }
        public string Ruc { get; set; }
        public DateTime? FechaInicio { get; set; }
        public string Slogan { get; set; }
        public string Direccion { get; set; }
        public byte[] Logo { get; set; }
        public char Estado { get; set; }

        public EEmpresa()
        {
            
        }
    }
}
