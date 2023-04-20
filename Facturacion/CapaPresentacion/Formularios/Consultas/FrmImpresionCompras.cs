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
namespace CapaPresentacion.Formularios.Consultas
{
    public partial class FrmImpresionCompras : Form
    {
        public FrmImpresionCompras()
        {
            InitializeComponent();
            LlenarComboTipo();
           
        }

        private void LlenarComboCliente()
        {
            cboCliente.DataSource = NProveedor.BuscarProveedor("R",this.txtnombre.Text);
            cboCliente.ValueMember = "ProveedorNro";
            cboCliente.DisplayMember = "Proveedor";
        }

        private void LlenarComboTipo() 
        {
            cboTipoPago.DataSource = NTipoPago.Mostrar();
            cboTipoPago.ValueMember = "CodTipoPago";
            cboTipoPago.DisplayMember = "Descripcion";
        }


        private void FrmImpresionCompras_Load(object sender, EventArgs e)
        {
            
            //Por defecto el primer item del combo box
            this.cboFiltro.SelectedIndex = 0;
            //this.cboTipoPago.SelectedIndex = 0;

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            FrmComprasFiltro frm = new FrmComprasFiltro();
            //Rango de fecha desde y hasta
            frm.desde = this.dtpDesde.Value.ToString("dd-MM-yyyy");
            frm.hasta = this.dtpHasta.Value.ToString("dd-MM-yyyy");
            //Parametro de filtro
            if (cboFiltro.Text == "TODOS")
            {
                frm.filtro = null;
            }
            else
            {
                frm.filtro = this.cboFiltro.Text;
            }
            //Parametro de cliente
            if (cboCliente.Text == string.Empty)
            {
                frm.personanro = null;
            }
            else
            {
                frm.personanro = Convert.ToInt32(this.cboCliente.SelectedValue);
            }
            //Parametro de tipo de pago
            if (chkTodos.Checked)
            {
                frm.tipopago = null;
            }
            else
            {
                frm.tipopago = Convert.ToInt32(this.cboTipoPago.SelectedValue);
            }

            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            if(this.txtnombre.Text!=string.Empty) {
                this.LlenarComboCliente();
            }
            else 
            {
                this.cboCliente.Text = string.Empty; 
            } 
         
        }
    }
}
