using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NColaborador
    {
        public int PersonaNro { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public DTipoDocumento TipoDocumento { get; set; }
        public int? CiudadNro { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DUsuarios Usuario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }
        public double Salario { get; set; }


        public static string Insertar(EColaborador colaborador)
        {
            DColaborador objColaborador = new DColaborador();
            return objColaborador.InsertarColaborador(colaborador);
        }

        public static string Editar(EColaborador colaborador)
        {
            DColaborador objColaborador = new DColaborador();
            return objColaborador.EditarColaborador(colaborador);
        }


        public static DataTable Mostrar(int? usuarioNro)
        {
            DColaborador objColaborador = new DColaborador();
            return objColaborador.MostrarColaborador(usuarioNro);
        }

        public static DataTable MostrarColaboradorActivo()
        {
            DColaborador objColaborador = new DColaborador();
            return objColaborador.MostrarListaColaboradorActivo();
        }
    }
}
