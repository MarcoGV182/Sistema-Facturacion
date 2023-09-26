using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ETipoImpuesto
    {
        public int TipoImpuestoNro { get; set; }
        public string Descripcion { get; set; }
        public decimal PorcentajeIva { get; set; }
        public decimal BaseImponible { get; set; }

        public ETipoImpuesto()
        {

        }

        public ETipoImpuesto(int tipoimpuestonro, string descripcion, decimal porcentajeiva, decimal baseImponible, string textobuscar)
        {
            this.TipoImpuestoNro = tipoimpuestonro;
            this.Descripcion = descripcion;
            this.PorcentajeIva = porcentajeiva;
            this.BaseImponible = baseImponible;
        }
    }
}
