using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EDetalleAjuste
    {
        public int CodDetalleAjuste { get; set; }
        public int CodAjuste { get; set; }
        public int ArticuloNro { get; set; }
        public int Cantidad { get; set; }
        public double Costo { get; set; }
        public int StockAnterior { get; set; }

        public EDetalleAjuste()
        {

        }

        public EDetalleAjuste(int coddetalleajuste, int codajuste, int articulonro, int cantidad, double costo, int stockanterior)
        {
            this.CodDetalleAjuste = coddetalleajuste;
            this.CodAjuste = codajuste;
            this.Cantidad = cantidad;
            this.ArticuloNro = articulonro;
            this.Costo = costo;
            this.StockAnterior = stockanterior;
        }
    }
}
