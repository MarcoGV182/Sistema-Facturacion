using CapaDatos;
using CapaDatos.Reporting;
using CapaEntidades;
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
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<ECaja> ListaArqueos { get; set; }
        public DateTime FechaReport { get; set; }
        public double TotalApertura { get; private set; }
        public double TotalEntrega { get; private set; }
        public double TotalSaldo { get; private set; }
        public double TotalDiferencia { get; private set; }


        public void ResumenCajaReport(DateTime fechainicio, DateTime fechafin)
        {
            try
            {
                TotalApertura = 0;
                TotalEntrega = 0;
                TotalSaldo = 0;
                TotalDiferencia = 0;

                //Carga de variables de fechas
                FechaInicio = fechainicio;
                FechaFin = fechafin;
                FechaReport = DateTime.Now;

                //Carga de Lista DetalleVentas
                ListaArqueos = new List<ECaja>();
                DInformeCaja r = new DInformeCaja();
                var DtReporte = r.ResumenCajaPorFecha(FechaInicio, FechaFin);
                foreach (DataRow row in DtReporte.Rows)
                {
                    ECaja nCajas = new ECaja()
                    {
                        NroCaja = Convert.ToInt32(row[0]),
                        UsuarioLogin = row[1].ToString(),
                        FechaApertura =  Convert.ToDateTime(row[2]),
                        FechaCierre = Convert.ToDateTime(row[3]),
                        ImporteApertura = Convert.ToDouble(row[4]),
                        ImporteEntrega = Convert.ToDouble(row[5]),
                        SaldoFinal = Convert.ToDouble(row[6]),
                        Diferencia = Convert.ToDouble(row[7]),
                        Estado = Convert.ToChar(row[8])
                       
                    };

                    ListaArqueos.Add(nCajas);
                }

                //Carga variables de totales
                TotalApertura = ListaArqueos.Sum(c => c.ImporteApertura);
                TotalEntrega = ListaArqueos.Sum(c => c.ImporteEntrega);
                TotalSaldo = ListaArqueos.Sum(c => c.SaldoFinal);
                TotalDiferencia = ListaArqueos.Sum(c => c.Diferencia);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
