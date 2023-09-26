using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using CapaEntidades;
using System.Text.RegularExpressions;

namespace CapaNegocio
{
    public class NMarca
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(EMarca eMarca)
        {
            DMarca objMarca = new DMarca();
            return objMarca.InsertarMarca(eMarca);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(EMarca marca)
        {
            DMarca objMarca = new DMarca();
            return objMarca.EditarMarca(marca);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int MarcaNro)
        {
            DMarca objMarca = new DMarca();
            return objMarca.EliminarMarca(MarcaNro);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static List<EMarca> Mostrar()
        {
            List<EMarca> listaMarca = new List<EMarca>();
            try
            {
                var MarcaDT = new DMarca().MostrarMarca();

                foreach (DataRow item in MarcaDT.Rows)
                {
                    EMarca marca = new EMarca()
                    {
                        MarcaNro = Convert.ToInt32(item[0]),
                        Descripcion = item[1].ToString()
                    };
                    listaMarca.Add(marca);
                }
                return listaMarca;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

       
    }
}
