using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaces
{
    internal interface IPersona
    {
        int PersonaNro { get; set; }
        string Nombre { get; set; }
        string Apellido { get; set; }
        string Documento { get; set; }
        DTipoDocumento TipoDocumento { get; set; }        
        int? CiudadNro { get; set; }
        string Direccion { get; set; }
        string Telefono { get; set; }
        string Email { get; set; }
        string Observacion { get; set; }
        DateTime? FechaNacimiento { get; set; }
    }
}
