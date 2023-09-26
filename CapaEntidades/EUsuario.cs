using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EUsuario
    {
        public int PersonaNro { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string passNew { get; set; }
        public int TipoUserNro { get; set; }
        public string TextoBuscar { get; set; }
        public string[] ReglaUsuario { get; set; }

        public EUsuario()
        {
                
        }


    }
}
