using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DFormaPago:Conexion
    {

        private int _FormaPagoNro;
        private string _Descripcion;
        private string _Abreviatura;

        public int FormaPagoNro
        {
            get
            {
                return _FormaPagoNro;
            }

            set
            {
                _FormaPagoNro = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }

        public string Abreviatura
        {
            get
            {
                return _Abreviatura;
            }

            set
            {
                _Abreviatura = value;
            }
        }


        public DFormaPago() { }

        public DFormaPago(int formapagonro,string descripcion, string abreviatura) 
        {
            this.FormaPagoNro = formapagonro;
            this.Descripcion = descripcion;
            this.Abreviatura = abreviatura;
        }


        //Metodo Mostrar
        public DataTable MostrarFormaPago()
        {
            DataTable DtResultado = new DataTable("FormaPago");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon = AbrirConexion();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarFormaPago";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            finally 
            {
                CerrarConexion(Sqlcon);
            }

            return DtResultado;

        }



    }
}
