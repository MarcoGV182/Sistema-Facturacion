using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
using CapaEntidades;

namespace CapaNegocio
{
    public class NTipoImpuesto
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(ETipoImpuesto eTipoImpuesto)
        {
            DTipoImpuesto objTipoImpuesto = new DTipoImpuesto();
            return objTipoImpuesto.InsertarImpuesto(eTipoImpuesto);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(ETipoImpuesto eTipoImpuesto)
        {
            DTipoImpuesto objTipoImpuesto = new DTipoImpuesto();
            return objTipoImpuesto.EditarImpuesto(eTipoImpuesto);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int tipoimpuestonro)
        {
            DTipoImpuesto objTipoImpuesto = new DTipoImpuesto();
            return objTipoImpuesto.EliminarImpuesto(tipoimpuestonro);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static List<ETipoImpuesto> Mostrar()
        {
            List<ETipoImpuesto> lstTipoImpuesto = new List<ETipoImpuesto>();
            try
            {                
                var tipoImpuestoDT = new DTipoImpuesto().MostrarImpuesto();
                foreach (DataRow item in tipoImpuestoDT.Rows)
                {
                    ETipoImpuesto ti = new ETipoImpuesto()
                    {
                        TipoImpuestoNro = Convert.ToInt32(item[0]),
                        Descripcion = item[1].ToString(),
                        BaseImponible = Convert.ToInt32(item[2]),
                        PorcentajeIva = Convert.ToInt32(item[3])
                    };

                    lstTipoImpuesto.Add(ti);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

            return lstTipoImpuesto;
        }
    }
}
