using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DPagoFactura:Conexion
    {
        public int PagoNro { get; set; }
        public int NroVenta { get; set; }
        public double Monto { get; set; }


        public string EliminarPagos(int nroVenta,SqlConnection sqlConexionExistente,SqlTransaction sqltranExistente) 
        {
            string rpta = "OK";
            SqlConnection Sqlcon = new SqlConnection();
            SqlTransaction Sqltran = null;
            try
            {
                //codigo            
                Sqlcon = AbrirConexion(sqlConexionExistente);
                //establecer la transaccion
                Sqltran = sqltranExistente ?? Sqlcon.BeginTransaction();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = Sqltran;
                SqlCmd.CommandText = "sp_EliminarPagoFactura";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Parametros 
                SqlParameter ParNroVenta = new SqlParameter();
                ParNroVenta.ParameterName = "@NroVenta";
                ParNroVenta.SqlDbType = SqlDbType.Int;
                ParNroVenta.Value = nroVenta;
                SqlCmd.Parameters.Add(ParNroVenta);

                //ejecutar el comando sql
                SqlCmd.ExecuteNonQuery();

                if (sqltranExistente == null)
                    Sqltran.Commit();

            }
            catch (Exception ex)
            {
                if (sqltranExistente == null)
                    Sqltran.Rollback();

                rpta = ex.Message;
            }
            finally
            {
                CerrarConexion(Sqlcon,ref sqlConexionExistente);
            }
            return rpta;

        }
    }


    public class RegistroPagoFacturacion:Conexion
    {
        public DPagoFacturaEfectivo Efectivo { get; set; }
        public DPagoFacturaTarjeta Tarjeta { get; set; }
        public DPagoFacturaCheque Cheque { get; set; }
        public DPagoFacturaOtros Otro { get; set; }




        public string EditarPagos(int nroVenta, RegistroPagoFacturacion pagos)
        {
            string rpta = "OK";
            SqlConnection Sqlcon = new SqlConnection();
            SqlTransaction Sqltran = null;
            try
            {
                #region Conexión
                //codigo            
                Sqlcon = AbrirConexion();
                //establecer la transaccion
                Sqltran = Sqlcon.BeginTransaction();
                //establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.Transaction = Sqltran;
                #endregion

                #region Eliminar Pagos
                DPagoFactura pago = new DPagoFactura();
                rpta = pago.EliminarPagos(nroVenta, Sqlcon, Sqltran);
                #endregion

                #region Registrar
                if (rpta.Equals("OK"))
                {
                    #region Registrar Pagos
                    if (pagos != null)
                    {
                        if (pagos.Efectivo != null)
                        {
                            DPagoFacturaEfectivo ef = new DPagoFacturaEfectivo();
                            pagos.Efectivo.NroVenta = nroVenta;
                            rpta = ef.InsertarPagoFacturaEfectivo(pagos.Efectivo, Sqlcon, Sqltran);
                            if (!rpta.Equals("OK"))
                                throw new Exception(rpta);
                        }


                        if (pagos.Tarjeta != null)
                        {
                            DPagoFacturaTarjeta tj = new DPagoFacturaTarjeta();
                            pagos.Tarjeta.NroVenta = nroVenta;
                            rpta = tj.InsertarPagoFacturaTarjeta(pagos.Tarjeta, Sqlcon, Sqltran);
                            if (!rpta.Equals("OK"))
                                throw new Exception(rpta);
                        }

                        if (pagos.Cheque != null)
                        {
                            DPagoFacturaCheque cq = new DPagoFacturaCheque();
                            pagos.Cheque.NroVenta = nroVenta;
                            rpta = cq.InsertarPagoFacturaCheque(pagos.Cheque, Sqlcon, Sqltran);
                            if (!rpta.Equals("OK"))
                                throw new Exception(rpta);
                        }

                        if (pagos.Otro != null)
                        {
                            DPagoFacturaOtros ot = new DPagoFacturaOtros();
                            pagos.Otro.NroVenta = nroVenta;
                            rpta = ot.InsertarPagoFacturaOtros(pagos.Otro, Sqlcon, Sqltran);
                            if (!rpta.Equals("OK"))
                                throw new Exception(rpta);
                        }
                    }
                    #endregion
                }
                #endregion

                if (rpta.Equals("OK"))
                {   
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
                CerrarConexion(Sqlcon);
            }
            return rpta;
        }
    }

        
   


}
