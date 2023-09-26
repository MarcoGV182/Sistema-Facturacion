using CapaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ECliente: IPersona
    {
        public string TextoBuscar { get; set; }
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
        public DateTime? FechaNacimiento { get; set; }
        public int Edad { get => CalcularEdad(); }


        public ECliente()
        {
                
        }

        public ECliente(int clienteNro, string nombre, string apellido, string documento, DateTime? fechaNacimiento, int ciudadNro, string direccion, string telefono, string email, string observacion, string textobuscar)
        {
            this.PersonaNro = clienteNro;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Documento = documento;
            this.FechaNacimiento = fechaNacimiento;
            this.CiudadNro = ciudadNro;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Observacion = observacion;
            this.TextoBuscar = textobuscar;
        }

        public int CalcularEdad()
        {
            // Obtiene la fecha actual:
            DateTime fechaActual = DateTime.Today;


            if (FechaNacimiento.Value == null)
            {
                return 0;
            }

            // Comprueba que la se haya introducido una fecha válida; si 
            // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje 
            // de advertencia:
            if (FechaNacimiento.Value > fechaActual)
            {
                return 0;
            }
            else
            {
                int edad = fechaActual.Year - FechaNacimiento.Value.Year;

                // Comprueba que el mes de la fecha de nacimiento es mayor 
                // que el mes de la fecha actual:
                if (FechaNacimiento.Value.Month > fechaActual.Month)
                {
                    --edad;
                }

                return edad;
            }
        }        
    }
}
