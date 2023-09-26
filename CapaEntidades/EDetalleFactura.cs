using CapaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EDetalleFactura
    {
        public int NroVenta { get; set; }
        public int NroItem { get; set; }
        public int CodDetalle { get; set; }
        public IArticulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public ETipoImpuesto TipoImpuesto { get; set; }
        public double Precio { get; set; }
        public double PrecioFinal { get; set; }
        public double SubTotalIVA { get; set; }
        public double SubTotalNeto { get; set; }
        public double SubTotalGral { get; set; }


        public EDetalleFactura()
        {

        }
    }
}
