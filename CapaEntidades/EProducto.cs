using CapaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EProducto:IArticulo
    {       
        public string Descripcion { get; set; }
        public ETipoProducto TipoProducto { get; set; }
        public EPresentacionProducto Presentacion { get; set; }
        public string CodigoBarra { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public EUnidadMedida UnidadMedida { get; set; }
        public ETipoImpuesto TipoImpuesto { get; set; }
        public EMarca Marca { get; set; }
        public int Stockminimo { get; set; }
        public int StockActual { get; set; }
        public double PrecioCompra { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }


        public int ArticuloNro { get ; set ; }
        public double Precio { get ; set ; }
        public TipoArticulo tipoArticulo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaUltActualizacion { get; set; }

        public EProducto()
        {
            
        }

    }
}
