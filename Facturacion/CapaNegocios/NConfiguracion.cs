using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace CapaNegocio
{
    public class NConfiguracion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Observacion { get; set; }


        public static NConfiguracion ObtenerConfiguracion(string nombre) 
        {

            DConfiguracion cf = new DConfiguracion();
            var DT = cf.GetConfiguracion(nombre);

            NConfiguracion configuracion = new NConfiguracion() 
            {
                Id = DT.Id,
                Nombre = DT.Nombre,
                Valor = DT.Valor,
                Observacion = DT.Observacion
            };
            

            return configuracion;
        }
    }
}
