using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;


namespace CapaNegocio
{
    public class NGastos
    {
        //Metodo para insertar que llama al metodo insertar de la capa Datos
        public static string Insertar(string nrodocumento ,DateTime fecha, decimal importe, int nrotipooperacion,int tipoimpuestonro,int formapagonro ,string descripcion,int usuario)
        {
            DGastos objGasto = new DGastos();
            objGasto.NroDocumento = nrodocumento;
            objGasto.Fecha = fecha;
            objGasto.Importe = importe;
            objGasto.NroTipoOperacion = nrotipooperacion;
            objGasto.Descripcion = descripcion;
            objGasto.TipoImpuestoNro = tipoimpuestonro;
            objGasto.FormaPagoNro = formapagonro;
            objGasto.Usuario = usuario;
            return objGasto.InsertarGasto(objGasto);
        }

        //Metodo para editar que llama al metodo insertar de la capa Datos
        public static string Editar(int gastonro, string nrodocumento, DateTime fecha, decimal importe, int nrotipooperacion, int tipoimpuestonro, int formapagonro, string descripcion) 
        {
            DGastos objGasto = new DGastos();
            objGasto.GastoNro = gastonro;
            objGasto.NroDocumento = nrodocumento;
            objGasto.Fecha = fecha;
            objGasto.Importe = importe;
            objGasto.NroTipoOperacion = nrotipooperacion;
            objGasto.Descripcion = descripcion;
            objGasto.TipoImpuestoNro = tipoimpuestonro;
            objGasto.FormaPagoNro = formapagonro;
            return objGasto.EditarGasto(objGasto);

        }

        //Metodo para eliminar que llama al metodo eliminar de la capa Datos
        public static string Eliminar(int gastonro)
        {
            DGastos objGasto = new DGastos();
            objGasto.GastoNro = gastonro;
            return objGasto.EliminarGasto(objGasto);
        }


        //Metodo para mostrar que llama al metodo mostrar de la capa Datos
        public static DataTable Mostrar()
        {
            return new DGastos().MostrarGasto();
        }


        public static DataTable MostrarNumeracion()
        {
            return new DGastos().MostrarNumeracionGastos();
        }


        public static DataTable BuscarNombre(string textobuscar) 
        {
            DGastos obj = new DGastos();
            obj.TextoBuscar = textobuscar; 
            return obj.BuscarNombre(obj); 
  
        }

        public static DataTable BuscarFecha(string textobuscar, string textobuscar2)
        {
            DGastos obj = new DGastos();
            return obj.BuscarGastoFecha(textobuscar, textobuscar2);

        }


    }
}
