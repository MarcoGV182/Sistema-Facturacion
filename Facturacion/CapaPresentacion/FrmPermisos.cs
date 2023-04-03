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
using System.Configuration;
using CapaDatos;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class FrmTipoUsuario_Regla : Form
    {
        public FrmTipoUsuario_Regla()
        {            
            InitializeComponent();
            this.LlenarCombos();
        }

        private static FrmTipoUsuario_Regla _Instancia;

        public static FrmTipoUsuario_Regla GetInstancia() 
        { 
            if(_Instancia==null) 
            {
                _Instancia = new FrmTipoUsuario_Regla();
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
            cboModulo.DataSource = NModulo.Mostrar();
            cboModulo.DisplayMember = "Descripcion";
            cboModulo.ValueMember = "IdModulo";
            cboModulo.SelectedIndex = 0;

            cboRoles.ValueMember = "IdRol";
            cboRoles.DisplayMember = "Nombre";
            cboRoles.DataSource = NTipoUsuario.Mostrar();            
            cboRoles.SelectedIndex = 0;

        }


        private void Mostrar()
        {
            try
            {
                if (cboRoles.Items.Count <= 0 || cboModulo.Items.Count <= 0)
                    return;

                chktodos.Checked = false;

                int idModulo = Convert.ToInt32(cboModulo.SelectedValue);
                int idRol = Convert.ToInt32(cboRoles.SelectedValue);               
                dataListado.DataSource = NTipoUsuarioRegla.Mostrar(idRol, idModulo);

                this.OcultarColumnas();
                lblTotal.Text = "Total de registros " + Convert.ToString(dataListado.Rows.Count);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
           
        }


        private void OcultarColumnas()
        {
            this.dataListado.Columns["IdOperacion"].Visible = false;
        }

        private void FrmTipoUsuario_Regla_Load(object sender, EventArgs e)
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

        private void FrmTipoUsuario_Regla_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void cboTipoUsuario_SelectedValueChanged(object sender, EventArgs e)
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

        private void chktodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chktodos.Checked == true)
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    row.Cells["Habilitado"].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    row.Cells["Habilitado"].Value = false;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string delete = "";
            string inserted = "";
            
            try
            {
                //delete = NTipoUsuarioRegla.Eliminar(Convert.ToInt32(cboRoles.SelectedValue));
                foreach (DataGridViewRow row in dataListado.Rows)
                {   
                    string habilitado = Convert.ToBoolean(row.Cells["Habilitado"].Value) ? "S" : "N";
                    inserted = NTipoUsuarioRegla.Insertar(Convert.ToInt32(row.Cells["IdOperacion"].Value), Convert.ToInt32(cboRoles.SelectedValue), habilitado);

                    if (!inserted.Equals("OK"))
                        break;
                
                }

                if(inserted.Equals("OK") || inserted.Equals("VACIO")) 
                { 
                    MessageBox.Show("Se ha insertado con exito"); 
                }
                else
                {
                    this.MensajeError(inserted);
                    return;
                }

                Mostrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }  
            
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Habilitado"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Habilitado"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void cboModulo_SelectedValueChanged(object sender, EventArgs e)
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
