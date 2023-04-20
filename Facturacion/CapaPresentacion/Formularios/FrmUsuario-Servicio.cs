using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using System.Data.SqlClient;

namespace CapaPresentacion.Formularios
{
    public partial class FrmUsuario_Servicio : Form
    {
        public FrmUsuario_Servicio()
        {
            InitializeComponent();
            this.LlenarCombos();

        }

        private static FrmUsuario_Servicio _Instancia;

        public static FrmUsuario_Servicio GetInstancia() 
        { 
            if(_Instancia==null) 
            {
                _Instancia = new FrmUsuario_Servicio();
            }
            return _Instancia;
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


        private void LlenarCombos()
        {
            //llenar combo Marca    
            
            cboEmpleados.DisplayMember = "NombreApellido";
            cboEmpleados.ValueMember = "ColaboradorNro";
            cboEmpleados.DataSource = NColaborador.MostrarColaboradorActivo();
        }


        private void Mostrar()
        {
            try
            {
                this.dataListado.DataSource = NUsuarioServicio.Mostrar(Convert.ToInt32(cboEmpleados.SelectedValue));
                //this.OcultarColumnas();
                lblTotal.Text = "Total de registros " + Convert.ToString(dataListado.Rows.Count);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
           
        }
        
        private void FrmUsuario_Servicio_Load(object sender, EventArgs e)
        {
            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 50;
            
           
        }

        private void cboTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
           // this.Mostrar();
        }

        private void FrmUsuario_Servicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void chktodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chktodos.Checked == true)
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    row.Cells["Selected"].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    row.Cells["Selected"].Value = false;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string delete = "";
            string inserted = "";
            
            try
            {
                delete = NUsuarioServicio.Eliminar(Convert.ToInt32(cboEmpleados.SelectedValue));
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Selected"].Value))
                    {                       
                        inserted = NUsuarioServicio.Insertar(Convert.ToInt32(row.Cells["ServicioNro"].Value), Convert.ToInt32(cboEmpleados.SelectedValue));
                    }
                    else
                    {
                        inserted = "VACIO";
                    }

                }

                if(inserted.Equals("OK") || inserted.Equals("VACIO")) 
                { 
                    MessageBox.Show("Se ha actualizado con exito"); 
                }
                else
                {
                    this.MensajeError(inserted);
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }  
            
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Selected"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Selected"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void cboEmpleados_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Mostrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
