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

namespace CapaPresentacion
{
    public partial class FrmProceso : Form
    {
        private char estado;
        //atributos para podes modificar los datos
        public int procesonro;
        public string descripcion;
        public DateTime fechainicio;
        public DateTime fechafin;
        public char estado2;
        public int id;



        public FrmProceso()
        {
            InitializeComponent();
        }

        private static FrmProceso _Instancia;
        public static FrmProceso GetInstancia() 
        { 
            if(_Instancia==null) 
            {
                _Instancia = new FrmProceso();   
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



        //metodo para mostrar los datos en el datagrid
        public void Mostrar()
        {
            if(this.cboEstado.Text=="ABIERTOS") 
            {
                estado = 'A';
            }
            else
            {
                estado = 'C';
            }
            
            this.dataListado.DataSource = NProceso.Mostrar(estado);
            //this.OcultarColumnas();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataListado.Rows.Count);
        }


       



        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmCrearProceso frm = FrmCrearProceso.GetInstancia();
            frm.id = Convert.ToInt32(id);
            frm.ShowDialog();
        }

        private void FrmProceso_Load(object sender, EventArgs e)
        {
            
            //top para ubicar en la parte superior
            this.Top = 0;
            //alineado hacia la izquierda
            this.Left = 0;
            this.cboEstado.SelectedIndex = 0;

            this.Mostrar();
        }

        private void FrmProceso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        public void cboEstado_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(dataListado.Rows.Count>0) 
            {
                FrmMantenimiento_Proceso frm = FrmMantenimiento_Proceso.GetInstancia();
                procesonro = Convert.ToInt32(this.dataListado.CurrentRow.Cells["ProcesoNro"].Value);
                descripcion = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion"].Value);
                fechainicio = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaInicio"].Value);
                fechafin = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["FechaFin"].Value);
                estado = Convert.ToChar(this.dataListado.CurrentRow.Cells["Estado"].Value);

                frm.ObtenerValores(procesonro, descripcion, fechainicio, fechafin, estado);

                frm.ShowDialog();
            }
            else
            {
                MensajeError("Seleccione una fila");
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult opcion;
                opcion = MessageBox.Show("Desea eliminar el proceso?", "Sistema de Facturacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    string codigo;
                    string rpta = "";

                    
                            codigo = Convert.ToString(dataListado.CurrentRow.Cells["ProcesoNro"].Value);
                            rpta = NProceso.Eliminar(Convert.ToInt32(codigo));

                            if (rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se elimino correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError("El proceso ya se encuentra cerrado" + Environment.NewLine + "Abra el proceso si desea eliminar");
                            }
                        
               }

                   this.Mostrar();
               }
                
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }
    }
}
