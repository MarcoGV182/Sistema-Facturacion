using CapaDatos;
using CapaDatos.Reporting;
using CapaEntidades;
using CapaEntidades.Reporting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Reporting
{
    public class NInformeCaja
    {        
        public EInformeCaja eInformeCaja;
        public void ResumenCajaReport(DateTime fechainicio, DateTime fechafin)
        {            
            try
            {
                eInformeCaja = new EInformeCaja();
                eInformeCaja.TotalApertura = 0;
                eInformeCaja.TotalEntrega = 0;
                eInformeCaja.TotalSaldo = 0;
                eInformeCaja.TotalDiferencia = 0;

                //Carga de variables de fechas
                eInformeCaja.FechaInicio = fechainicio;
                eInformeCaja.FechaFin = fechafin;
                eInformeCaja.FechaReport = DateTime.Now;

                //Carga de Lista DetalleVentas
                List<ECaja> ListaArqueos = new List<ECaja>();
                DInformeCaja r = new DInformeCaja();
                var DtReporte = r.ResumenCajaPorFecha(eInformeCaja.FechaInicio, eInformeCaja.FechaFin);
                foreach (DataRow row in DtReporte.Rows)
                {
                    ECaja nCajas = new ECaja();
                    nCajas.NroCaja = Convert.ToInt32(row[0]);
                    nCajas.UsuarioLogin = row[1].ToString();
                    nCajas.FechaApertura = Convert.ToDateTime(row[2]);
                    nCajas.FechaCierre = Convert.IsDBNull(row[3]) ? (DateTime?)null : Convert.ToDateTime(row[3]);
                    nCajas.ImporteApertura = Convert.ToDouble(row[4]);
                    nCajas.ImporteEntrega = Convert.IsDBNull(row[5]) ? (double?)null : Convert.ToDouble(row[5]);
                    nCajas.SaldoFinal = Convert.IsDBNull(row[6]) ? (double?)null : Convert.ToDouble(row[6]);
                    nCajas.Diferencia = Convert.IsDBNull(row[7]) ? (double?)null : Convert.ToDouble(row[7]);
                    nCajas.Estado = Convert.ToChar(row[8]);

                    ListaArqueos.Add(nCajas);
                }

                //Carga variables de totales
                eInformeCaja.TotalApertura = ListaArqueos.Sum(c => c.ImporteApertura);
                eInformeCaja.TotalEntrega = ListaArqueos.Sum(c => c.ImporteEntrega.GetValueOrDefault());
                eInformeCaja.TotalSaldo = ListaArqueos.Sum(c => c.SaldoFinal.GetValueOrDefault());
                eInformeCaja.TotalDiferencia = ListaArqueos.Sum(c => c.Diferencia.GetValueOrDefault());
                eInformeCaja.ListaArqueos = ListaArqueos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
