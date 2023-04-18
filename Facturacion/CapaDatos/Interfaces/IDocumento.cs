using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaces
{
    public interface IDocumento
    {
        int Id { get; set; }
        int Establecimiento { get; set; }
        int PuntoExpedicion { get; set; }
        int Numero { get; set; }


        string Anular(int id,int usuario);
    }

   
}
