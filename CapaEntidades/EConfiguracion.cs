﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EConfiguracion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Observacion { get; set; }

        public EConfiguracion()
        {
            
        }
    }
}
