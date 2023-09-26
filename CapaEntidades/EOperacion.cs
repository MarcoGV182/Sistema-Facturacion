using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EOperacion
    {
        public int IdOperacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdModulo { get; set; }
        public EModulo Modulo { get; set; }
        public bool Habilitado { get; set; }


        public EOperacion()
        {
                
        }
    }
}
