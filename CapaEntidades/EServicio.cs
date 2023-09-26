using CapaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EServicio:IArticulo
    {
        public int ArticuloNro { get; set; }
        public string Descripcion { get; set; }
        public int TipoServicioNro { get; set; }
        public ETipoServicio TipoServicio { get; set; }
        public int TipoImpuestoNro { get; set; }
        public ETipoImpuesto TipoImpuesto { get; set; }
        public double Precio { get; set; }       
        public int PorcentajeComision { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaRegistro { get; set; }        
        public TipoArticulo tipoArticulo { get ; set ; }
        public DateTime FechaUltActualizacion { get ; set; }

        public EServicio()
        {
                
        }
    }
}
