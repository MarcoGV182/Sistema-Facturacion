using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        string Insertar(T clase);
        string Editar(T clase);
        DataTable Mostrar();
        string Eliminar(int id);

    }
}
