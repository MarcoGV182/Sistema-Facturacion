using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NTipoDocumento
    {
        
        public static DataTable Mostrar() 
        {
            DTipoDocumento tipoDocumento = new DTipoDocumento();
            return tipoDocumento.MostrarTipoDocumento();
        }
    }
}
