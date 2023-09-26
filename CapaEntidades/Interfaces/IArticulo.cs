using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Interfaces
{
    public interface IArticulo
    {
        int ArticuloNro { get; set; }
        string Descripcion { get; set; }
        ETipoImpuesto TipoImpuesto { get; set; }
        double Precio { get; set; }
        string Observacion { get; set; }
        string Estado { get; set; }
        TipoArticulo tipoArticulo{ get; set; }
        DateTime FechaRegistro { get; set; }
        DateTime FechaUltActualizacion { get; set; }

    }

    public enum TipoArticulo 
    { 
        Servicio,
        Producto    
    }
}
