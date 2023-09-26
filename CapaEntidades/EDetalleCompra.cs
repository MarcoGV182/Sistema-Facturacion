using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EDetalleCompra
    {
        public int idCompra { get; set; }
        public int DetalleCompraNro { get; set; }
        public int NroItem { get; set; }
        public ETipoImpuesto TipoImpuesto { get; set; }
        public int ProductoNro { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public EDetalleCompra()
        {
            
        }

        public EDetalleCompra(int detallecompraNro, string nrofacturacompra, int proveedornro, int productonro, int cantidad, decimal precioCompra)
        {
            this.DetalleCompraNro = detallecompraNro;
            this.ProductoNro = proveedornro;
            this.ProductoNro = productonro;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioCompra;
        }
    }
}
