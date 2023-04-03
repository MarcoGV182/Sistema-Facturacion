using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public static class FormularioManager
    {
        public static void AbrirFormulario(Form formulario, params object[] datos)
        {
            MethodInfo metodo = formulario.GetType().GetMethod("AsignarDatos");
            metodo.Invoke(formulario, new object[] { datos });
            formulario.Show();
        }
    }
}
