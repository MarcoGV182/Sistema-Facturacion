﻿using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NRaza
    {
        #region Propiedades
        public int Id { get; set; }
        public string Descripcion { get; set; }
        #endregion

        #region Constructor
        public NRaza()
        {

        }
        #endregion

        #region Metodos
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(string descripcion)
        {
            DRaza objRaza = new DRaza();
            objRaza.Descripcion = descripcion;
            return objRaza.Insertar(objRaza);
        }

        //Metodo para editar que llama al metodo editar de la capa Datos
        public static string Editar(DRaza marca)
        {
            DRaza objMarca = new DRaza();
            return objMarca.Editar(marca);
        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int raza)
        {
            DRaza objRazas = new DRaza();
            return objRazas.Eliminar(raza);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static List<NRaza> MostrarListaRaza()
        {
            DRaza dRaza = new DRaza();
            List<NRaza> listaRaza = new List<NRaza>();
            DataTable Dt = dRaza.Mostrar();


            foreach (DataRow item in Dt.Rows)
            {
                NRaza r = new NRaza()
                {
                    Id = int.Parse(item["Id"].ToString()),
                    Descripcion = item["Descripcion"].ToString()
                };

                listaRaza.Add(r);
            }

            return listaRaza;
        }
        #endregion

    }
}
