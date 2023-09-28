﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ETipoPago
    {
        public int IdFormaPago { get; set; }
        public string Descripcion { get; set; }

        public ETipoPago()
        {
            
        }

        public ETipoPago(int FormaPago, string descripcion)
        {
            IdFormaPago = FormaPago;
            Descripcion = descripcion;
        }
    }
}
