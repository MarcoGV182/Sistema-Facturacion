using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EPresentacionProducto
    {
        public int IdPresentacion { get; set; }
        public string Descripcion { get; set; }
        public string TextoBuscar { get; set; }

        public EPresentacionProducto()
        {
                
        }

        public EPresentacionProducto(int idpresentacion, string descripcion, string textobuscar)
        {
            this.IdPresentacion = idpresentacion;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }
    }
}
