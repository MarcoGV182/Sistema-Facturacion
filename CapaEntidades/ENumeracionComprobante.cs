using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ENumeracionComprobante
    {
        public int Id { get; set; }
        public int TipoComprobante { get; set; }
        public int? Establecimiento { get; set; }
        public int? PuntoExpedicion { get; set; }
        public int NumeroDesde { get; set; }
        public int NumeroHasta { get; set; }
        public int NumeroActual { get; set; }
        public ETimbrado Timbrado { get; set; }
        public string Estado { get; set; }


        public ENumeracionComprobante() { }

        public ENumeracionComprobante(int id, int establecimiento, int puntoexpedicion, int tipocomprobante, int numerodesde, int numerohasta, ETimbrado timbrado, char estado)
        {
            this.Id = id;
            this.Establecimiento = establecimiento;
            this.PuntoExpedicion = puntoexpedicion;
            this.TipoComprobante = tipocomprobante;
            this.NumeroDesde = numerodesde;
            this.NumeroHasta = numerohasta;
            this.Timbrado = timbrado;
        }
    }
}
