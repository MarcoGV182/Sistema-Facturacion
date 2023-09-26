using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class EAjuste
    {
        public int CodAjuste { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public int TipoAjusteNro { get; set; }
        public string usuario { get; set; }

        public EAjuste()
        {
            
        }

        public EAjuste(int codajuste, string descripcion, DateTime fechahora, string estado, string observacion, int tipoajusteNro, string usuario)
        {
            this.CodAjuste = codajuste;
            this.Descripcion = descripcion;
            this.FechaHora = fechahora;
            this.Estado = estado;
            this.Observacion = observacion;
            this.TipoAjusteNro = tipoajusteNro;
            this.usuario = usuario;
        }
    }
}
