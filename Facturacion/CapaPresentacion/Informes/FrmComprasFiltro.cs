﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmComprasFiltro : Form
    {
        public string desde;
        public string hasta;
        public int? personanro;
        public int? tipopago;
        public string filtro;
        public FrmComprasFiltro()
        {
            InitializeComponent();
        }

        private void FrmComprasFiltro_Load(object sender, EventArgs e)
        {
            this.Top = 100;
            this.Left = 50;
            try 
            {
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteCompraPorFecha' Puede moverla o quitarla según sea necesario.
                DsReporte.sp_ReporteCompraPorFecha.Clear();
                DsReporte.EnforceConstraints = false;
                // TODO: esta línea de código carga datos en la tabla 'DsReporte.sp_ReporteCompraPorFecha' Puede moverla o quitarla según sea necesario.
                this.sp_ReporteCompraPorFechaTableAdapter.Fill(this.DsReporte.sp_ReporteCompraPorFecha, desde, hasta, filtro, personanro, tipopago);

                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
