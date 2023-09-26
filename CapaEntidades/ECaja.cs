using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class ECaja
    {
        public int NroCaja { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }
        public int PersonaNro { get; set; }
        public string UsuarioLogin { get; set; }
        public double ImporteApertura { get; set; }
        public char Estado { get; set; }
        public string Observacion { get; set; }
        public double ImporteEntrega { get; set; }
        public double Diferencia { get; set; }
        public double SaldoFinal { get; set; }

        public ECaja()
        {
            
        }

        //constructor con parametros
        public ECaja(int nroCaja, DateTime fechaApertura, DateTime? fechaCierre, int personaNro, char estado, double importeApertura, double importeentrega, double saldofinal, double diferencia, string observacion)
        {
            this.NroCaja = NroCaja;
            this.FechaApertura = fechaApertura;
            this.FechaCierre = fechaCierre;
            this.PersonaNro = personaNro;
            this.Estado = estado;
            this.ImporteApertura = importeApertura;
            this.ImporteEntrega = importeentrega;
            this.SaldoFinal = saldofinal;
            this.Diferencia = diferencia;
            this.Observacion = observacion;
        }

    }
}
