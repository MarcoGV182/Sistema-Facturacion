using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NFormaPago
    {
        public static DataTable MostrarFormaPago()
        {
            DFormaPago obj = new DFormaPago();
            return obj.MostrarFormaPago();
        }


    }
}
