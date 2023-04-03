using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NProceso
    {
        //INSERTAR FILA
        public static string Insertar(string descripcion, string mes, DateTime fechainicio, DateTime fechafin,int usuarionro)
        {
            DProceso obj = new DProceso();
            obj.Descripcion = descripcion;
            obj.Mes = mes;
            obj.FechaInicio = fechainicio;
            obj.FechaFin = fechafin;
            obj.UsuarioNro = usuarionro;
            return obj.InsertarProceso(obj);
        }
        //EDITAR FILA
        public static string Editar(int Procesonro, string descripcion, string mes, DateTime fechainicio,DateTime fechafin)
        {
            DProceso obj = new DProceso();
            obj.ProcesoNro = Procesonro;
            obj.Descripcion = descripcion;
            obj.Mes = mes;
            obj.FechaInicio = fechainicio;
            obj.FechaFin = fechafin;
            return obj.EditarProceso(obj);
        }


        //ELIMINAR FILA
        public static string Eliminar(int procesonro)
        {
            DProceso obj = new DProceso();
            obj.ProcesoNro = procesonro;
            return obj.EliminarProceso(obj);
        }

        //MOSTRAR DATOS
        public static DataTable Mostrar(char estado)
        {
            DProceso obj = new DProceso();
            obj.Estado = estado;
            return obj.MostrarProceso(obj);
        }


        public static DataTable MostrarUsuarioServicio(int procesonro)
        {
            DProceso obj = new DProceso();
            obj.ProcesoNro = procesonro;
            return obj.MostrarServicioUsuario(obj);
        }

        public static DataTable BuscarUsuarioServicio(int procesonro, int usuarionro)
        {
            DProceso obj = new DProceso();
            obj.ProcesoNro = procesonro;
            obj.UsuarioNro = usuarionro;
            return obj.BuscarServicioUsuario(obj);
        }





        public static string CerrarProceso(int procesonro)
        {
            DProceso obj = new DProceso();
            obj.ProcesoNro = procesonro;
            return obj.CerrarProceso(obj);

        }

        public static string AbrirProceso(int procesonro)
        {
            DProceso obj = new DProceso();
            obj.ProcesoNro = procesonro;
            return obj.AbrirProceso(obj);

        }

    }
}
