using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos.Interfaces;

namespace CapaDatos
{
    public class DCompra : IDocumento
    {
        public int Id { get; set; }
        public int Establecimiento { get; set; }
        public int PuntoExpedicion { get; set; }
        public int Numero { get; set; }
        public string NroFacturaCompra { get; set; }
        public DProveedor Proveedor { get; set; }
        public DateTime Fecha { get; set; }
        public DTipoPago TipoPago { get; set; }
        public int CantCuotas { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string NroTimbrado { get; set; }
        public DTipoComprobante TipoComprobate { get; set; }
        public string Usuario { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
        public List<DDetalleIngreso> DetalleCompra { get; set; }




        public DCompra() {

        }

        //Metodo insertar
        public string Insertar(DCompra Compra)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            SqlTransaction Sqltran = null;
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer la transaccion
                Sqltran = Sqlcon.BeginTransaction();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = Sqltran;
                SqlCmd.CommandText = "sp_InsertarCompra";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParNroFacturaCompraSalida = new SqlParameter();
                ParNroFacturaCompraSalida.ParameterName = "@NroCompra";
                ParNroFacturaCompraSalida.SqlDbType = SqlDbType.VarChar;
                ParNroFacturaCompraSalida.Size = 50;
                ParNroFacturaCompraSalida.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParNroFacturaCompraSalida);

                //Parametros 
                SqlParameter ParProveedorNro = new SqlParameter();
                ParProveedorNro.ParameterName = "@ProveedorNro";
                ParProveedorNro.SqlDbType = SqlDbType.Int;
                ParProveedorNro.Value = Compra.Proveedor.PersonaNro;
                SqlCmd.Parameters.Add(ParProveedorNro);

                //Parametros 
                SqlParameter ParEstablecimiento = new SqlParameter();
                ParEstablecimiento.ParameterName = "@Establecimiento";
                ParEstablecimiento.SqlDbType = SqlDbType.Int;
                ParEstablecimiento.Value = Compra.Establecimiento;
                SqlCmd.Parameters.Add(ParEstablecimiento);


                //Parametros 
                SqlParameter ParPuntoExpedicion = new SqlParameter();
                ParPuntoExpedicion.ParameterName = "@PuntoExpedicion";
                ParPuntoExpedicion.SqlDbType = SqlDbType.Int;
                ParPuntoExpedicion.Value = Compra.PuntoExpedicion;
                SqlCmd.Parameters.Add(ParPuntoExpedicion);

                //Parametros 
                SqlParameter ParNumero = new SqlParameter();
                ParNumero.ParameterName = "@Numero";
                ParNumero.SqlDbType = SqlDbType.Int;
                ParNumero.Value = Compra.Numero;
                SqlCmd.Parameters.Add(ParNumero);


                //Parametros 
                SqlParameter ParNroFactura = new SqlParameter();
                ParNroFactura.ParameterName = "@NroFacturaCompra";
                ParNroFactura.SqlDbType = SqlDbType.VarChar;
                ParNroFactura.Value = Compra.NroFacturaCompra;
                SqlCmd.Parameters.Add(ParNroFactura);

                //Parametros Razon Social
                SqlParameter ParRazonSocial = new SqlParameter();
                ParRazonSocial.ParameterName = "@RazonSocial";
                ParRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParRazonSocial.Size = 100;
                ParRazonSocial.Value = Compra.Proveedor.RazonSocial;
                SqlCmd.Parameters.Add(ParRazonSocial);

             
                //Parametros Fecha Compra
                SqlParameter ParFechaCompra = new SqlParameter();
                ParFechaCompra.ParameterName = "@Fecha";
                ParFechaCompra.SqlDbType = SqlDbType.Date;
                ParFechaCompra.Value = Compra.Fecha;
                SqlCmd.Parameters.Add(ParFechaCompra);

                //Parametros TipoPago
                SqlParameter ParFormaPago = new SqlParameter();
                ParFormaPago.ParameterName = "@CodTipoPago";
                ParFormaPago.SqlDbType = SqlDbType.Int;
                ParFormaPago.Value = Compra.TipoPago.FormaPago;
                SqlCmd.Parameters.Add(ParFormaPago);

                //Parametros tipo de comprobante
                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@TipoComprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 50;
                ParTipoComprobante.Value = Compra.TipoComprobate.ComprobanteNro;
                SqlCmd.Parameters.Add(ParTipoComprobante);

                //Parametros Dias
                SqlParameter ParDias = new SqlParameter();
                ParDias.ParameterName = "@CantCuotas";
                ParDias.SqlDbType = SqlDbType.Int;
                ParDias.Value = Compra.CantCuotas;
                SqlCmd.Parameters.Add(ParDias);

                // Parametros Fecha Compra
                SqlParameter ParVencimiento = new SqlParameter();
                ParVencimiento.ParameterName = "@Vencimiento";
                ParVencimiento.SqlDbType = SqlDbType.DateTime;
                ParVencimiento.Value = Compra.FechaVencimiento;
                SqlCmd.Parameters.Add(ParVencimiento);

                // Parametros Timbrado
                SqlParameter ParNroTimbrado = new SqlParameter();
                ParNroTimbrado.ParameterName = "@NroTimbrado";
                ParNroTimbrado.SqlDbType = SqlDbType.VarChar;
                ParNroTimbrado.Value = Compra.NroTimbrado;
                SqlCmd.Parameters.Add(ParNroTimbrado);


                //Parametros Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 9;
                ParEstado.Value = Compra.Estado;
                SqlCmd.Parameters.Add(ParEstado);

                //Parametros Observacion
                SqlParameter ParObservacion = new SqlParameter();
                ParObservacion.ParameterName = "@Observacion";
                ParObservacion.SqlDbType = SqlDbType.VarChar;
                ParObservacion.Size = 256;
                ParObservacion.Value = Compra.Observacion;
                SqlCmd.Parameters.Add(ParObservacion);


                //Parametros usuario
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.Int;
                ParUsuario.Value = Compra.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);



                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se inserto el registro";

                if(rpta.Equals("OK")) 
                {
                //Obtener el NroCompra
                    this.Id = Convert.ToInt32(SqlCmd.Parameters["@NroCompra"].Value);                    
                    
                    foreach(DDetalleIngreso det in Compra.DetalleCompra) {
                        det.idCompra = this.Id;
                        
                        //Llamar al metodo insertar
                        rpta = det.InsertarDetalleCompra(det, ref Sqlcon,ref Sqltran);
                        if(!rpta.Equals("OK")) 
                        {
                            break;
                        }
                        else 
                        {
                            //Aumentar stock
                            this.AumentarStock(det.ProductoNro, det.Cantidad, Sqlcon, Sqltran);
                        }
                    }
                }
                if (rpta.Equals("OK"))
                {
                    rpta = $"{this.Id};OK";
                    Sqltran.Commit();
                }
                else
                {
                    Sqltran.Rollback();
                }

            }
            catch (Exception ex)
            {
                Sqltran.Rollback();
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon);
            }
            return rpta;
        }



        //Metodo Anular
        public string Anular(int id, string usuario)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_AnularCompra";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParNroFacturaCompra = new SqlParameter();
                ParNroFacturaCompra.ParameterName = "@NroCompra";
                ParNroFacturaCompra.SqlDbType = SqlDbType.VarChar;
                ParNroFacturaCompra.Value = id;
                SqlCmd.Parameters.Add(ParNroFacturaCompra);

                
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Value = usuario;
                SqlCmd.Parameters.Add(ParUsuario);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se anuló el registro";
                


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                    Sqlcon.Close();
            }

            return rpta;
        }


        //Metodo Eliminar
        public string EliminarCompra(DCompra Compra)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EliminarCompra";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParNroFacturaCompra = new SqlParameter();
                ParNroFacturaCompra.ParameterName = "@NroCompra";
                ParNroFacturaCompra.SqlDbType = SqlDbType.Int;
                ParNroFacturaCompra.Value = Compra.Id;
                SqlCmd.Parameters.Add(ParNroFacturaCompra);

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() >= 1 ? "OK" : "No se eliminó el registro";
                
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                    Sqlcon.Close();
            }
            return rpta;
        }


        //Metodo Restaurar Stock despues de eliminar una compra
        public string RestaurarStock(DCompra Compra)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_RestaurarStockCompra";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParNroFacturaCompra = new SqlParameter();
                ParNroFacturaCompra.ParameterName = "@NroCompra";
                ParNroFacturaCompra.SqlDbType = SqlDbType.Int;
                ParNroFacturaCompra.Value = Compra.Id;
                SqlCmd.Parameters.Add(ParNroFacturaCompra);


                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se restauró con exito";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                    Sqlcon.Close();
            }

            return rpta;
        }





        //Metodo Buscar
        public DataTable BuscarFechas(string Textobuscar1, string TextoBuscar2)
        {
            DataTable DtResultado = new DataTable("Compra");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_BuscarCompraFechas";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@FechaInicio";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.SqlValue = Textobuscar1;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //Parametros
                SqlParameter ParTextoBuscar2 = new SqlParameter();
                ParTextoBuscar2.ParameterName = "@FechaFin";
                ParTextoBuscar2.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar2.SqlValue = TextoBuscar2;
                SqlCmd.Parameters.Add(ParTextoBuscar2);

                //instanciar un DataAdapter
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Metodo Mostrar
        public DataTable MostrarDetalleCompra(int NroCompra)
        {
            DataTable DtResultado = new DataTable("DetalleCompra");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarDetalleCompra";
                SqlCmd.CommandType = CommandType.StoredProcedure;              

                // Parametros
                SqlParameter ParNroCompra = new SqlParameter();
                ParNroCompra.ParameterName = "@NroCompra";
                ParNroCompra.SqlDbType = SqlDbType.Int;
                ParNroCompra.SqlValue = NroCompra;
                SqlCmd.Parameters.Add(ParNroCompra);

                //instanciar un DataAdapter
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            finally 
            {
                Conexion.CerrarConexion(Sqlcon);            
            }
            return DtResultado;
        }


        //Metodo Mostrar
        public DataTable MostrarCompra()
        {
            DataTable DtResultado = new DataTable("Compra");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarCompra";
                SqlCmd.CommandType = CommandType.StoredProcedure;
               

                //instanciar un DataAdapter
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


        //Metodo Mostrar
        public DataTable MostrarCompraAnulada()
        {
            DataTable DtResultado = new DataTable("Compra");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_MostrarCompraAnulada";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //instanciar un DataAdapter
                SqlDataAdapter SqlAdapter = new SqlDataAdapter(SqlCmd);
                SqlAdapter.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }





        //Metodo Aumentar el Stock
        public string AumentarStock(int Articulonro, int cantidad, SqlConnection SqlconExistente = null, SqlTransaction sqltranExistente = null)
        {
            string rpta = "OK";
            SqlConnection Sqlcon = null;
            try
            {
                //codigo
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion, SqlconExistente);
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = sqltranExistente;
                SqlCmd.CommandText = "sp_AumentarStock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParArticuloNro = new SqlParameter();
                ParArticuloNro.ParameterName = "@ArticuloNro";
                ParArticuloNro.SqlDbType = SqlDbType.Int;
                ParArticuloNro.Value = Articulonro;
                SqlCmd.Parameters.Add(ParArticuloNro);

                //Parametros 
                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

                if (sqltranExistente == null)
                    sqltranExistente.Commit();
            }
            catch (Exception ex)
            {
                if (sqltranExistente == null)
                    sqltranExistente.Rollback();

                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon, ref SqlconExistente);
            }
            return rpta;
        }



        //Metodo Disminuir el Stock
        public string DescontarStock(int Articulonro, int cantidad, SqlConnection SqlconExistente = null, SqlTransaction sqltranExistente = null)
        {
            string rpta = "OK";
            SqlConnection Sqlcon = null;
            try
            {   
                //codigo
                Sqlcon = Conexion.AbrirConexion(Conexion.CadenaConexion, SqlconExistente);
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_DescontarStock";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParArticuloNro = new SqlParameter();
                ParArticuloNro.ParameterName = "@ArticuloNro";
                ParArticuloNro.SqlDbType = SqlDbType.Int;
                ParArticuloNro.Value = Articulonro;
                SqlCmd.Parameters.Add(ParArticuloNro);

                //Parametros 
                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

                if (sqltranExistente == null)
                    sqltranExistente.Commit();
            }
            catch (Exception ex)
            {
                if (sqltranExistente == null)
                    sqltranExistente.Rollback();
                rpta = ex.Message;
            }
            finally
            {
                Conexion.CerrarConexion(Sqlcon,ref SqlconExistente);
            }
            return rpta;
        }



        //Actualizar estado de CUENTAPORPAGAR 
        public string CuentaAPagar(DCompra Compra)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //codigo
                Sqlcon.ConnectionString = Conexion.CadenaConexion;
                Sqlcon.Open();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "sp_EditarEstadoCuentaPagarCompra";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Parametros
                SqlParameter ParNroFactura = new SqlParameter();
                ParNroFactura.ParameterName = "@NroCompra";
                ParNroFactura.SqlDbType = SqlDbType.Int;
                ParNroFactura.Value = Compra.Id;
                SqlCmd.Parameters.Add(ParNroFactura);

                

                //ejecutar el comando sql
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo la Compra";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open)
                    Sqlcon.Close();
            }
            return rpta;
        }



    }
}
