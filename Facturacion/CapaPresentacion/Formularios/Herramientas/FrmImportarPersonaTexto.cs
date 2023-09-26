using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion.Formularios.Herramientas
{
    public partial class FrmImportarPersonaTexto : Form
    {
        public string Archivo = "";

        public FrmImportarPersonaTexto()
        {
            InitializeComponent();
        }

        private static FrmImportarPersonaTexto _Instancia;
        public static FrmImportarPersonaTexto GetInstancia() 
        {
            if (_Instancia==null)
            {
                _Instancia = new FrmImportarPersonaTexto();
            }
            return _Instancia;
        }
        

        public static void nombrartitulo(DataGridView tabla, string[] titulos)
        {
            int x = 0;
            for (x = 0; x <= tabla.ColumnCount - 1; x++)
            {
                tabla.Columns[x].HeaderText = titulos[x];
            }
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



        public static void AgregarFilaDatagrid(DataGridView tabla, string linea, char caracter, int fila)
        {
            string[] arreglo = linea.Split(caracter);
            tabla.Rows.Add(arreglo);
        }



        public void LeerArchivo(DataGridView tabla, char caracter, string ruta)
        {
            StreamReader objReader = new StreamReader(ruta);
            string sLine = "";
            int fila = 0;
            tabla.Rows.Clear();
            do
            {
                sLine = objReader.ReadLine();
                if ((sLine != null))
                {
                    if (fila == 0)
                    {
                        tabla.ColumnCount = sLine.Split(caracter).Length;
                        nombrartitulo(tabla, sLine.Split(caracter));
                        fila += 1;
                    }
                    else
                    {
                        AgregarFilaDatagrid(tabla, sLine, caracter, fila);
                        fila += 1;
                    }

                }
            } while (!(sLine == null));
            objReader.Close();

        }


        public void CargarArchivo()
        {
            try
            {
                this.openFileDialog1.ShowDialog();
                if (!string.IsNullOrEmpty(this.openFileDialog1.FileName))
                {
                    Archivo = this.openFileDialog1.FileName;
                    this.LeerArchivo(dataArchivo,Convert.ToChar(txtCaracter.Text), Archivo);
                }

                label2.Text="TOTAL DE REGISTROS: " + this.dataArchivo.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCaracter.Text==string.Empty)
            {
                MensajeError("Inserte un caracter");
            }
            else
            {
                CargarArchivo();
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                string rpta = "";
                foreach (DataGridViewRow row in dataArchivo.Rows)
                {
                    //rpta = NCliente.ImportarTexto(Convert.ToString(row.Cells[2].Value).Trim(), Convert.ToString(row.Cells[1].Value).Trim(), Convert.ToString(row.Cells[0].Value) + "-" + Convert.ToString(row.Cells[3].Value).Trim());  
                }

                if (rpta.Equals("OK"))
                {
                    MessageBox.Show("SE INSERTARON CON EXITO");
                }
                else
                {
                    MessageBox.Show("Ocurrio un error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmImportarPersonaTexto_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }
    }
}
