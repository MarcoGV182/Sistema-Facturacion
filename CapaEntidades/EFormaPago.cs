using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EFormaPago
    {
        public int FormaPagoNro { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }

        public EFormaPago()
        {
            
        }

        public EFormaPago(int formapagonro, string descripcion, string abreviatura)
        {
            this.FormaPagoNro = formapagonro;
            this.Descripcion = descripcion;
            this.Abreviatura = abreviatura;
        }
    }
}
