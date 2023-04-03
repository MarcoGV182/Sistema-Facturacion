using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NOrdenTrabajo
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(DateTime fecha, int clienteNro, string formula, int? dias, DateTime? fechavisita, string observacion,int usuarioinsercion, string nombreusuario ,DataTable dtDetalleOT)
        {
            DOrdenTrabajo objOT = new DOrdenTrabajo();
            objOT.Fecha = fecha;
            objOT.ClienteNro = clienteNro;
            objOT.Formula=formula;
            objOT.Dias = dias;
            objOT.FechaVisita = fechavisita;
            objOT.Observacion = observacion;
            objOT.UsuarioInsercion = usuarioinsercion;
            objOT.NombreUsuario = nombreusuario;
            
            //DETALLES DE OT 
            List<DDetalleOrdenTrabajo> detalles = new List<DDetalleOrdenTrabajo>();
            foreach (DataRow row in dtDetalleOT.Rows)
            {
                DDetalleOrdenTrabajo dtOrdenTrabajo = new DDetalleOrdenTrabajo();
                if(!row.IsNull("UsuarioNro")) 
                {
                    // dtOrdenTrabajo.NroOT = Convert.ToInt32(row["NroOT"].ToString());
                    dtOrdenTrabajo.ServicioNro = Convert.ToInt32(row["ItemNro"].ToString());
                    dtOrdenTrabajo.UsuarioNro = Convert.ToInt32(row["UsuarioNro"].ToString());
                    dtOrdenTrabajo.Precio = Convert.ToDecimal(row["Precio"].ToString());
                    dtOrdenTrabajo.Comision = Convert.ToDecimal(row["ComisionServicio"].ToString());
                    dtOrdenTrabajo.Ganancia = Convert.ToDecimal(row["Ganancia"].ToString());
                    detalles.Add(dtOrdenTrabajo);
                }
               
            }
            return objOT.InsertarOT(objOT, detalles);
        }


        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Editar(int nroOT, DateTime fecha, int clienteNro, string formula, int? dias, DateTime? fechavisita, string observacion, DataTable dtDetalleOT)
        {
            DOrdenTrabajo objOT = new DOrdenTrabajo();
            objOT.NroOT = nroOT;
            objOT.Fecha = fecha;
            objOT.ClienteNro = clienteNro;
            objOT.Formula = formula;
            objOT.Dias = dias;
            objOT.FechaVisita = fechavisita;
            objOT.Observacion = observacion;
            //DETALLES DE COMPRAS
            List<DDetalleOrdenTrabajo> detalles = new List<DDetalleOrdenTrabajo>();
            foreach (DataRow row in dtDetalleOT.Rows)
            {
                DDetalleOrdenTrabajo dtOrdenTrabajo = new DDetalleOrdenTrabajo();

                dtOrdenTrabajo.ServicioNro = Convert.ToInt32(row["ItemNro"].ToString());
                dtOrdenTrabajo.UsuarioNro = Convert.ToInt32(row["UsuarioNro"].ToString());
                dtOrdenTrabajo.Precio = Convert.ToDecimal(row["Precio"].ToString());
                dtOrdenTrabajo.Comision = Convert.ToDecimal(row["ComisionServicio"].ToString());
                dtOrdenTrabajo.Ganancia = Convert.ToDecimal(row["Ganancia"].ToString());
                detalles.Add(dtOrdenTrabajo);
            }
            return objOT.EditarOT(objOT, detalles);
        }



        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string EliminarOT(int nroOt)
        {
            DOrdenTrabajo objOT = new DOrdenTrabajo();
            objOT.NroOT = nroOt;
            return objOT.EliminarOT(objOT);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DOrdenTrabajo().MostrarOT();
        }

        //Metodo para buscar que llama al metodo buscar por nombre de la capa Datos
        public static DataTable BuscarOTFecha(string fecha1, string fecha2)
        {
            DOrdenTrabajo objOT = new DOrdenTrabajo();

            return objOT.BuscarOTFecha(fecha1, fecha2);
        }

        public static DataTable MostrarDetalle(int nroot)
        {
            DOrdenTrabajo objOT = new DOrdenTrabajo();
            objOT.NroOT = nroot;
            return objOT.MostrarDetalleOT(nroot);
        }


        public static DataTable MostrarNumeracion() 
        {
            return new DOrdenTrabajo().MostrarNumeracionOT();
        }



        //MOSTRAR CABECERA OT EN LA FACTURA
        public static DataTable MostrarCabOTFactura(string numeracion)
        {
            DOrdenTrabajo objOT = new DOrdenTrabajo();
            return objOT.MostrarCabOTFactura(numeracion);
        }



        public static DataTable MostrarDetOTFactura(string numeracion)
        {
            DOrdenTrabajo objOT = new DOrdenTrabajo();
            return objOT.MostrarOTFactura(numeracion);
        }


    }
}
