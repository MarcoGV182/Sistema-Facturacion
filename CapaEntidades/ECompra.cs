using CapaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ECompra: IDocumento
    {
        public int Id { get; set; }
        public int Establecimiento { get; set; }
        public int PuntoExpedicion { get; set; }
        public int Numero { get; set; }
        public string NroFacturaCompra { get; set; }
        public EProveedor Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public ETipoPago TipoPago { get; set; }
        public int? CantCuotas { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string NroTimbrado { get; set; }
        public ETipoComprobante TipoComprobate { get; set; }
        public string Usuario { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
        public List<EDetalleCompra> DetalleCompra { get; set; }
    }
}
