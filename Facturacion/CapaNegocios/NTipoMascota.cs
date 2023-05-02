using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NTipoMascota
    {   
        #region Propiedades
        public int Id { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Constructor
        public NTipoMascota()
        {

        }
        #endregion

        #region Metodos
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(string descripcion)
        {
            DTipoMascota objRaza = new DTipoMascota();
            objRaza.Descripcion = descripcion;
            return objRaza.Insertar(objRaza);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(DTipoMascota marca)
        {
            DTipoMascota objMarca = new DTipoMascota();
            return objMarca.Editar(marca);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int id)
        {
            DTipoMascota objTipoMascota = new DTipoMascota();
            return objTipoMascota.Eliminar(id);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static List<NTipoMascota> Mostrar()
        {            
            List<NTipoMascota> listaRaza = new List<NTipoMascota>();

            DTipoMascota DTipoMascota = new DTipoMascota();
            DataTable Dt = DTipoMascota.Mostrar();

            if (Dt != null)
            {
                foreach (DataRow item in Dt.Rows)
                {
                    NTipoMascota r = new NTipoMascota()
                    {
                        Id = int.Parse(item["Id"].ToString()),
                        Descripcion = item["Descripcion"].ToString()
                    };

                    listaRaza.Add(r);
                }
            }            

            return listaRaza;
        }
        #endregion
    }
}
