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
        public int ClienteNro { get; set; }
        public string NombreCliente { get; set; }
        public DateTime Fecha { get; set; }
        public int CodTipoPago { get; set; }
        public int TipoComprobanteNro { get; set; }
        public string Estado { get; set; }
        public ETimbrado Timbrado { get; set; }
        public string Observacion { get; set; }
        public string Usuario { get; set; }
        public int? Vendedor { get; set; }
        public int? CantCuota { get; set; }
        public int NroOrden { get; set; }
        public string Ind_Autoimprenta { get; set; }
        public int? ColaboradorNro { get; set; }

        public EFactura()
        {
            
        }

        public EFactura(int nroVenta, string nroFactura, int clienteNro, string nombrecliente, int establecimiento, int puntoexpedicion, int numero, ETimbrado timbrado, DateTime fecha, int codtipopago, int tipoComprobante, string estado, string observacion, string usuario)
        {
            this.Id = nroVenta;
            this.NroFactura = nroFactura;
            this.ClienteNro = clienteNro;
            this.NombreCliente = nombrecliente;
            this.Establecimiento = establecimiento;
            this.PuntoExpedicion = puntoexpedicion;
            this.Numero = numero;
            this.Timbrado = timbrado;
            this.Fecha = fecha;
            this.CodTipoPago = codtipopago;
            this.TipoComprobanteNro = tipoComprobante;
            this.Estado = estado;
            this.Observacion = observacion;
            this.Usuario = usuario;
        }
    }
}
