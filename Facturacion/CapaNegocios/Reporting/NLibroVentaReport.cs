using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaDatos.Reporting;
using CapaEntidades;
using CapaEntidades.Reporting;

namespace CapaNegocio
{
    public class NLibroVentaReport
    {
        public ELibroVentaReport eLibroVentaReport;
        public void LibroVentaReport(DateTime fechainicio,DateTime fechafin, string Estado) 
        {                        
            try
            {
                eLibroVentaReport = new ELibroVentaReport();
                eLibroVentaReport.TotalGravada = 0;
                eLibroVentaReport.TotalIVA = 0;
                eLibroVentaReport.TotalExento = 0;
                eLibroVentaReport.TotalGral = 0;

                //Carga de variables de fechas
                eLibroVentaReport.FechaInicio = fechainicio;
                eLibroVentaReport.FechaFin = fechafin;
                eLibroVentaReport.FechaReport = DateTime.Now;

                //Carga de Lista DetalleVentas
                List<EDetalleDeVentas> eDetalleDeVentas = new List<EDetalleDeVentas>();
                DLibroCompraReport r = new DLibroCompraReport();
                var DtReporte = r.ObtenerLibroVenta(eLibroVentaReport.FechaInicio, eLibroVentaReport.FechaFin, Estado);
                foreach (DataRow row in DtReporte.Rows)
                {
                    EDetalleDeVentas nDetalleDeVentas = new EDetalleDeVentas()
                    {
                        NroVenta = Convert.ToInt32(row[0]),
                        Fecha = Convert.ToDateTime(row[1]),
                        NroFactura = row[2].ToString(),
                        Comprobante = row[3].ToString(),
                        Cliente = row[4].ToString(),
                        TipoDocumento = row[5].ToString(),
                        NroDocumento = row[6].ToString(),
                        Imp_Gravado = Convert.ToDouble(row[7]),
                        Imp_IVA = Convert.ToDouble(row[8]),
                        Imp_Exento = Convert.ToDouble(row[9]),
                        Total = Convert.ToDouble(row[10])
                    };

                    eDetalleDeVentas.Add(nDetalleDeVentas);
                }

                //Carga variables de totales
                eLibroVentaReport.TotalGravada = eDetalleDeVentas.Sum(c => c.Imp_Gravado);
                eLibroVentaReport.TotalIVA = eDetalleDeVentas.Sum(c => c.Imp_IVA);
                eLibroVentaReport.TotalExento = eDetalleDeVentas.Sum(c => c.Imp_Exento);
                eLibroVentaReport.TotalGral = eDetalleDeVentas.Sum(c => c.Total);
                eLibroVentaReport.DetallesVentas = eDetalleDeVentas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
