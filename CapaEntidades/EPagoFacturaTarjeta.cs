using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EPagoFacturaTarjeta: EPagoFactura
    {
        public string TipoTarjeta { get; set; }
        public string ComprobanteNro { get; set; }

        public EPagoFacturaTarjeta() { }
        public EPagoFacturaTarjeta(int pagoNro, int nroventa, string tipotarjeta, double monto, string comprobanteNro)
        {
            this.PagoNro = pagoNro;
            this.NroVenta = nroventa;
            this.TipoTarjeta = tipotarjeta;
            this.Monto = monto;
            this.ComprobanteNro = comprobanteNro;
        }

    }
}
