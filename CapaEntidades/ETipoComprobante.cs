﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ETipoComprobante
    {
        public int ComprobanteNro { get; set; }
        public string Nombre { get; set; }
        public bool AfectaCaja { get; set; }

        public ETipoComprobante()
        {
            
        }

    }
}
