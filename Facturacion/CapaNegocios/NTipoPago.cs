using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NTipoPago
    {
        public static DataTable Mostrar() {
            DTipoPago objTipoPago = new DTipoPago();
            return objTipoPago.MostrarTipoPago();
        }



        public static DataTable MostrarTipoPagoOtros()
        {
            DTipoPagoOtros objTipoPago = new DTipoPagoOtros();
            return objTipoPago.MostrarTipoPagoOtros();
        }

    }
}
