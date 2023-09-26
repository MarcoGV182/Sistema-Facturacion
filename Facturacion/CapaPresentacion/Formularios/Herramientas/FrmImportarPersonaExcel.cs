using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.OleDb;
using System.Data.SqlClient;
using CapaNegocio;

namespace CapaPresentacion.Formularios.Herramientas
{
    public partial class FrmImportarPersonaExcel : Form
    {

        private static FrmImportarPersonaExcel _Instancia;

        public static FrmImportarPersonaExcel GetInstancia() {
            if(_Instancia==null) {
                _Instancia = new FrmImportarPersonaExcel(); 
            }
            return _Instancia;
        }

        public FrmImportarPersonaExcel()
        {
            InitializeComponent();
        }


        //Metodo de mensaje de confirmacion
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Metodo de mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }




        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openUrlExcel = new OpenFileDialog();
            openUrlExcel.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
            openUrlExcel.Title = "Seleccionar archivo excel";

            if (openUrlExcel.ShowDialog() == DialogResult.OK)
            {
                txturl.Text = openUrlExcel.FileName;
                string excelConectionConfig;
                excelConectionConfig = "provider=Microsoft.ACE.OLEDB.12.0;";
                excelConectionConfig += "Data Source =" + openUrlExcel.FileName + "; ";
                excelConectionConfig += "Extended Properties='Excel 12.0;HDR=YES'";

                OleDbConnection excelConnection = default(OleDbConnection);
                excelConnection = new OleDbConnection(excelConectionConfig);

                OleDbCommand filterRows = default(OleDbCommand);
                filterRows = new OleDbCommand("Select * From [Hoja1$]", excelConnection);

                DataSet ds = new DataSet();
          

                try
                {
                    OleDbDataAdapter adaptador = default(OleDbDataAdapter);
                    adaptador = new OleDbDataAdapter();
                    adaptador.SelectCommand = filterRows;
                    adaptador.Fill(ds);
                    dataExcel.DataSource = ds.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MensajeError("Formato de Excel invalido");
                }
            }
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataExcel.Rows.Count);

        }

        private void FrmImportarPersona_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
           
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("Desea almacenar los registro en la BD ?", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (opcion == DialogResult.OK)
            {
                if (dataExcel.Rows.Count == 0)
                {
                    MensajeError("Por favor primero importe el archivo excel");
                }
                else
                {
                    try
                    {
                        foreach (DataGridViewRow row in dataExcel.Rows)
                        {
                            //NCliente.ImportarExcel(Convert.ToString(row.Cells["Nombre"].Value), Convert.ToString(row.Cells["Apellido"].Value), Convert.ToString(row.Cells["Documento"].Value));
                        }
                        MensajeOK("Se han insertado correctamente los datos");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void FrmImportarPersona_Load(object sender, EventArgs e)
        {
            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 0;
        }

        private void dataExcel_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataExcel.Rows.Count);
        }
    }
}
