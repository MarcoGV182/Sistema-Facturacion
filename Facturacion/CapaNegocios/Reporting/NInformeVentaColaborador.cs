using CapaDatos.Reporting;
using CapaEntidades.Reporting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace CapaNegocio.Reporting
{
    public class NInformeVentaColaborador
    {
        List<EDetalleInformeVentaColaborador> Detalleinforme;
        public int ColaboradorId { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public DateTime FechaReport { get; set; }
        public double TotalGralVenta { get; set; }


        public void ObtenerInformeVentaColaborador(DateTime FechaDesde,DateTime FechaHasta, int Colaborador) 
        {
           try
            {
                TotalGralVenta = 0;

                //Carga de variables de fechas
                Desde = FechaDesde;
                Hasta = FechaHasta;
                FechaReport = DateTime.Now;
                ColaboradorId = Colaborador;

                //Carga de Lista DetalleVentas
                Detalleinforme = new List<EDetalleInformeVentaColaborador>();
                DInformeVentaColaborador r = new DInformeVentaColaborador();
                var DtReporte = r.InformeVentaColaborador(Desde, Hasta, ColaboradorId);
                foreach (DataRow row in DtReporte.Rows)
                {
                    EDetalleInformeVentaColaborador nDetalleDeVentas = new EDetalleInformeVentaColaborador()
                    {
                        NroVenta = Convert.ToInt32(row[0]),
                        NroFactura = row[1].ToString(),
                        Fecha= Convert.ToDateTime(row[2]),
                        NombreColaborador = row[3].ToString(),
                        DocumentoColaborador = row[4].ToString(),
                        TotalVenta = Convert.ToDouble(row[5]),
                        CantidadItems = Convert.ToInt16(row[6])
                    };

                    Detalleinforme.Add(nDetalleDeVentas);
                }

                //Carga variables de totales
                TotalGralVenta = Detalleinforme.Sum(c => c.TotalVenta);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
