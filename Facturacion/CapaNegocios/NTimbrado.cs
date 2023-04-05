using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NTimbrado
    {
        public static DataTable Mostrar()
        {
            DTimbrado timbrado = new DTimbrado();
            return timbrado.ObtenerTimbrado(); 
        }
    }
}
