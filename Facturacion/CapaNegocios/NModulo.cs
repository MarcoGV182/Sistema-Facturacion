using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class NModulo
    {
        public static /*List<DModulo>*/DataTable Mostrar() 
        { 
            DModulo d = new DModulo();
            return d.Mostrar();
        }

    }
}
