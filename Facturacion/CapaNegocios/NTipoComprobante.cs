using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NTipoComprobante
    {
        public static DataTable MostrarTipoComprobante()
        {
            DTipoComprobante tipoComprobante = new DTipoComprobante();
            return tipoComprobante.MostrarTipoComprobante();
        }
    }
}
