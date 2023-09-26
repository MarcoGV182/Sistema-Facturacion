using CapaEntidades.Interfaces;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EProveedor:IPersona
    {
        public DateTime? FechaAniversario { get; set; }
        public int PersonaNro { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public ETipoDocumento TipoDocumento { get; set; }
        public int? CiudadNro { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Observacion { get; set; }
        public string RazonSocial { get; set; }
        public string TextoBuscar { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public EProveedor()
        {
            
        }

        public EProveedor(int proveedorNro, string razonSocial, string ruc, int ciudadNro, string direccion, string telefono, string email, string representante, string textobuscar)
        {
            this.PersonaNro = proveedorNro;
            this.RazonSocial = razonSocial;
            this.Documento = ruc;
            this.CiudadNro = ciudadNro;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.TextoBuscar = textobuscar;
        }
    }
}
