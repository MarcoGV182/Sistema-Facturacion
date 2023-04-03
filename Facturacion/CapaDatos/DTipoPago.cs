using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTipoPago
    {
        private int _FormaPago;
        private string _Descripcion;

        public int FormaPago
        {
            get
            {
                return _FormaPago;
            }

            set
            {
                _FormaPago = value;
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


        public DTipoPago() {

        }

        public DTipoPago(int FormaPago, string descripcion) 
        {
            this.FormaPago = FormaPago;
            this.Descripcion = descripcion;
        }


        //Metodo Mostrar
        public DataTable MostrarTipoPago()
        {
            DataTable DtResultado = new DataTable("TipoPago");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarTipoPago";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }

            return DtResultado;

        }





    }
}
