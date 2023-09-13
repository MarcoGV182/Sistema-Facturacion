using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaDatos.Reporting;

namespace CapaNegocio
{
    public class NLibroVentaReport
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<NDetalleDeVentas> DetallesVentas { get; set; }
        public DateTime FechaReport { get; set; }
        public double TotalGravada { get; private set; }
        public double TotalIVA { get; private set; }
        public double TotalExento { get; private set; }
        public double TotalGral { get; private set; }


        public void LibroVentaReport(DateTime fechainicio,DateTime fechafin) 
        {
            try
            {
                TotalGravada = 0;
                TotalIVA = 0;
                TotalExento = 0;
                TotalGral = 0;

                //Carga de variables de fechas
                FechaInicio = fechainicio;
                FechaFin = fechafin;
                FechaReport = DateTime.Now;

                //Carga de Lista DetalleVentas
                DetallesVentas = new List<NDetalleDeVentas>();
                DLibroCompraReport r = new DLibroCompraReport();
                var DtReporte = r.ObtenerLibroVenta(FechaInicio, FechaFin);
                foreach (DataRow row in DtReporte.Rows)
                {
                    NDetalleDeVentas nDetalleDeVentas = new NDetalleDeVentas()
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

                    DetallesVentas.Add(nDetalleDeVentas);
                }

                //Carga variables de totales
                TotalGravada = DetallesVentas.Sum(c => c.Imp_Gravado);
                TotalIVA = DetallesVentas.Sum(c => c.Imp_IVA);
                TotalExento = DetallesVentas.Sum(c => c.Imp_Exento);
                TotalGral = DetallesVentas.Sum(c => c.Total);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
