using CapaDatos;
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
        public static string Insertar(DColaborador colaborador)
        {
            DColaborador objColaborador = new DColaborador();
            return objColaborador.InsertarColaborador(colaborador);
        }

        public static string Editar(DColaborador colaborador)
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
