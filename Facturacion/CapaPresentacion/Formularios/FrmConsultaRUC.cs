using Microsoft.Office.Interop.Excel;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class FrmConsultaRUC : Form
    {
        public string RUC_Nombre;
        private List<ERuc> ListRuc = new List<ERuc>();
        private Form _tipoFormulario;

        public FrmConsultaRUC()
        {
            InitializeComponent();
        }

        public FrmConsultaRUC(string ruc, Form tipoFormulario)
        {
            RUC_Nombre = ruc;
            _tipoFormulario = tipoFormulario;
            InitializeComponent();
        }

        private void FrmConsultaRUC_Load(object sender, EventArgs e)
        {
            CargarEventos();
            CargarPagina();
        }

        private void CargarEventos() 
        {
            webView21.NavigationCompleted += WebView21_NavigationCompleted;
        }

        private void WebView21_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                MessageBox.Show("No se pudo obtener los datos. Favor verifique su conexión a Internet");
                btnConsultar.Enabled = false;
            }
            else
            {
                btnConsultar.Enabled = true;
                /*EnviarEvento();
                ConsultarRUC();*/
            }
        }

        private async void CargarPagina() 
        {
            await webView21.EnsureCoreWebView2Async();
            webView21.CoreWebView2.Navigate("https://www.ruc.com.py/");
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            EnviarEvento();            
        }

        private async void EnviarEvento() 
        {
            string valor = "";
            if (!string.IsNullOrEmpty(RUC_Nombre))
            {
                valor = RUC_Nombre;
            }
            else
            {
                valor = txtRucNombre.Text;
            }

            await webView21.EnsureCoreWebView2Async();
            await webView21.CoreWebView2.ExecuteScriptAsync($"document.getElementById('txt_buscar').value = '{valor}';");
            ConsultarRUC();
        }

        private async void ConsultarRUC() 
        {
            await webView21.EnsureCoreWebView2Async();
            await webView21.CoreWebView2.ExecuteScriptAsync("document.getElementById('btn_buscar').click();");

            ListRuc = await GetTableDataAsync();
            dgListaRUC.DataSource = ListRuc;

            //EnviarDatosRUC(_tipoFormulario);
        }

        private async Task<List<ERuc>> GetTableDataAsync()
        {
            List<ERuc> tableData = new List<ERuc>();
            try
            {
                // Ejecutar un script de JavaScript para obtener los datos de la tabla con ID "myTable"
                //string script = @"JSON.stringify(Array.from(document.getElementById('base_ruc').rows).slice(1).map(row => Array.from(row.cells).reduce((acc, cell, i) => ({ ...acc, [document.getElementById('base_ruc').rows[0].cells[i].textContent]: cell.textContent }), {})))";
                string script = @"var table = document.getElementById('base_ruc');
                                    var rows = table.querySelectorAll('tbody tr');
                                    var data = [];
                                    for (var i = 0; i < rows.length; i++) {
                                        var row = rows[i];
                                        var cells = row.querySelectorAll('td');
                                        var rowData = {};
                                        rowData['RUC'] = cells[0].textContent.trim();
                                        rowData['RAZÓN SOCIAL'] = cells[1].textContent.trim();
                                        data.push(rowData);
                                    }
                                    JSON.stringify(data);";
                string result = await webView21.CoreWebView2.ExecuteScriptAsync(script);

                // Eliminar las barras invertidas escapadas
                string unescapedResult = Regex.Unescape(result);

                // Eliminar los caracteres de salto de línea dentro de las cadenas de texto
                string pattern = "(?<!\\\\)\\\\n";
                string noNewLineResult = Regex.Replace(unescapedResult, pattern, "").Replace("\\", "").Trim('\"');

                if (string.IsNullOrEmpty(noNewLineResult) || noNewLineResult.ToUpper().Equals("NULL"))
                {
                    MessageBox.Show("Sin datos");
                    return tableData;
                }

                tableData = JsonConvert.DeserializeObject<List<ERuc>>(noNewLineResult);
                //var tableData = JsonConvert.DeserializeObject<List<DRuc>>(noNewLineResult);
            }
            catch (Exception)
            {
            }

            return tableData;
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            CargarPagina();
        }


        public void EnviarDatosRUC(Form formulario) 
        {
            object[] datos = ListRuc.ToArray();
            FormularioManager.AbrirFormulario(formulario, datos);
        }
    }
}
