using CapaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EColaborador: IPersona
    {
        public int PersonaNro { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public ETipoDocumento TipoDocumento { get; set; }
        public int? CiudadNro { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public EUsuario Usuario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }
        public double Salario { get; set; }
        public bool HabilitadoVendedor { get; set; }
    }
}
