using CapaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EFactura: IDocumento
    {
        public int Id { get; set; }
        public int Establecimiento { get; set; }
        public int PuntoExpedicion { get; set; }
        public int Numero { get; set; }
        public string NroFactura { get; set; }
        public ECliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public ETipoPago TipoPago { get; set; }
        public ETipoComprobante TipoComprobante { get; set; }
        public string Estado { get; set; }
        public ETimbrado Timbrado { get; set; }
        public string Observacion { get; set; }
        public string Usuario { get; set; }
        public int? CantCuota { get; set; }
        public int NroOrden { get; set; }
        public string Ind_Autoimprenta { get; set; }
        public EColaborador ColaboradorVendedor { get; set; }
        public double ImporteIVA { get; set; }
        public double ImporteGravada { get; set; }
        public double ImporteExento { get; set; }
        public double Total { get => (ImporteIVA + ImporteGravada + ImporteExento); }
        public DateTime FechaInsercion { get; set; }
        public string UsuarioInsercion { get; set; }
        public DateTime? FechaAnulacion { get; set; }
        public string UsuarioAnulacion { get; set; }

        public EFactura()
        {
            
        }
    }
}
