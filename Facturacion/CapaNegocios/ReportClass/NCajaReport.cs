using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaNegocio.ReportClass;

namespace CapaNegocio.ReportClass
{
    public class NCajaReport
    {
        public DCaja DatosCaja { get; set; }
        public List<NMovimientoReport> ListaMovimientosCaja { get; set; }        
        public double TotalEfectivo { get; set; }        
        public double TotalTarjeta { get; set; }        
        public double TotalCheque { get; set; }
        public List<NDetalleOtrosPagosReport> ListaPagoOtros { get; set; }
        public double TotalOtros { get; set; }


        public void CrearReporteArqueoCaja(int nroArqueoCaja) 
        {
            //Obtener datos del arqueo
            #region Cabecera Arqueo
            DatosCaja = new DCaja();
            var result = DatosCaja.MostrarDatosArqueoCaja(nroArqueoCaja);
            foreach (DataRow row in result.Rows)
            {
                DatosCaja.NroCaja = Convert.ToInt32(row[0]);
                DatosCaja.FechaApertura = Convert.ToDateTime(row["FechaApertura"]);
                DatosCaja.FechaCierre = Convert.ToDateTime(row["FechaCierre"]);
                DatosCaja.ImporteEntrega = Convert.ToDouble(row["ImporteApertura"]);
                DatosCaja.SaldoFinal = Convert.ToDouble(row["SaldoFinal"]);
                DatosCaja.Diferencia = Convert.ToDouble(row["Diferencia"]);
                DatosCaja.Login = Convert.ToString(row["Usuario"]);
                DatosCaja.Observacion = Convert.ToString(row["Observacion"]);
                DatosCaja.Estado = Convert.ToString(row["Estado"]);
            }
            #endregion

            //Lista de Movimientos
            #region Detalle Movimientos Arqueo
            NMovimiento movim = new NMovimiento();
            var resultmov = movim.MostrarMovimientosArqueo(nroArqueoCaja);
            ListaMovimientosCaja = new List<NMovimientoReport>();
            foreach (DataRow row in resultmov.Rows)
            {
                NMovimientoReport m = new NMovimientoReport()
                {
                    NroDocumento = Convert.ToString(row[0]),
                    Fecha = Convert.ToDateTime(row[1]),
                    Concepto = Convert.ToString(row[2]),
                    Ingreso = Convert.ToDouble(row[4]),
                    Egreso = Convert.ToDouble(row[5])
                };
                ListaMovimientosCaja.Add(m);
            }
            #endregion

            //Lista de Pagos
            
            var resultPagosEfectivo = NPagoFactura.ObtenerPagoEfectivo(DatosCaja.FechaApertura, DatosCaja.FechaCierre.Value);
            TotalEfectivo = resultPagosEfectivo.AsEnumerable().Sum(row => Convert.ToDouble(row["Importe"]));

            var resultPagosTarjeta = NPagoFactura.ObtenerPagoTarjeta(DatosCaja.FechaApertura, DatosCaja.FechaCierre.Value);
            TotalTarjeta = resultPagosTarjeta.AsEnumerable().Sum(row => Convert.ToDouble(row["Importe"]));

            var resultPagosCheque = NPagoFactura.ObtenerPagoCheque(DatosCaja.FechaApertura, DatosCaja.FechaCierre.Value);
            TotalCheque = resultPagosCheque.AsEnumerable().Sum(row => Convert.ToDouble(row["Importe"]));


            var resultPagosOtro = NPagoFactura.ObtenerPagoOtro(DatosCaja.FechaApertura, DatosCaja.FechaCierre.Value);
            var listaAux = new List<NDetalleOtrosPagosReport>();
            foreach (DataRow row in resultPagosOtro.Rows)
            {
                NDetalleOtrosPagosReport m = new NDetalleOtrosPagosReport()
                {
                    TipoPago = Convert.ToString(row["Forma"]),
                    Total = Convert.ToDouble(row["Importe"])                   
                };
                listaAux.Add(m);
            }
            ListaPagoOtros = (from x in listaAux
                             group x by x.TipoPago into newgroup
                             select new NDetalleOtrosPagosReport()
                             {
                                 TipoPago = newgroup.Key,
                                 Total = newgroup.Sum(c => c.Total)
                             }).ToList();
            //Total pago otros
            TotalOtros = ListaPagoOtros.Sum(x => x.Total);

        }
    }
}
