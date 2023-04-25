using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaPresentacion.Formularios.Consultas;
using CapaPresentacion.Formularios.Facturacion;
using CapaPresentacion.Formularios.Gastos;
using CapaPresentacion.Formularios.Herramientas;
using CapaPresentacion.Formularios.Inventario;
using CapaPresentacion.Formularios.Mantenimiento;
using CapaPresentacion.Formularios.RRHH;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion.Formularios
{
    public partial class FormPrincipal : Form
    {
        private int childFormNumber = 0;
        public string id = "";
        public string usuario = "";
        public string nombre = "";
        public string apellido = "";
        public string acceso="";
        public string estado = "";
        public string[] reglas;

               
        public FormPrincipal()
        {
            InitializeComponent();
        }



        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                   

        /*private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }*/

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInformeProducto frm = new FrmInformeProducto();
            frm.MdiParent = this;
            frm.Show();
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup_BD frm = Backup_BD.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("Esta seguro que desea salir ?", "Sistema de Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {    
            FrmProducto frm = FrmProducto.GetInstancia();
            frm.MdiParent = this;
            frm.usuario = usuario;
            frm.reglas = reglas;
            frm.Show();
            frm.BringToFront();
          
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedor frm = FrmProveedor.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente frm = FrmCliente.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        public void CargarImagen() 
        {
            DataTable datos = new DataTable();
            datos = NEmpresa.Mostrar();

            try
            {
                if (ControlesCompartidos.ObtenerValorAppSettings().Equals("N"))
                {
                    return;
                }
                //PARA MOSTRAR LA IMAGEN
                byte[] imagenBuffer = (byte[])datos.Rows[0]["Logo"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
                this.BackgroundImage = Image.FromStream(ms);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception)
            {

            }
        }

        

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            #region CambiarColorMDI
            MdiClient ctlMDI;
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (InvalidCastException)
                {

                }
            }

            #endregion
            FrmRecordatorio frm = FrmRecordatorio.GetInstancia();
            frm.MdiParent = this;
            frm.Show();

            //ACCESOS DE USUARIOS
            txtnombreusuario.Text ="Usuario: " + nombre +" "+apellido;

            ValidarPermisosReglas(MenuMantenimiento);
            ValidarPermisosReglas(MenuFacturacion);
            ValidarPermisosReglas(MenuGastos);
            ValidarPermisosReglas(MenuConsultas);
            ValidarPermisosReglas(MenuInventario);
            ValidarPermisosReglas(MenuHerramientas);
            ValidarPermisosReglas(MenuRRHH);

            /*productosToolStripMenuItem.Visible = NUsuarios.VerificarPermisos("1", reglas);
            servicioToolStripMenuItem.Visible = NUsuarios.VerificarPermisos("2", reglas);
            ordenDeTrabajoToolStripMenuItem.Visible = NUsuarios.VerificarPermisos("3", reglas);
            empresaToolStripMenuItem.Visible=NUsuarios.VerificarPermisos("4", reglas);
            PersonaToolStripMenuItem.Visible = NUsuarios.VerificarPermisos("9",reglas);
            comprasToolStripMenuItem.Visible = NUsuarios.VerificarPermisos("6",reglas);
            ventasToolStripMenuItem.Visible = NUsuarios.VerificarPermisos("5", reglas);
            MenuConsultas.Visible = NUsuarios.VerificarPermisos("7", reglas);
            optionsToolStripMenuItem.Visible = NUsuarios.VerificarPermisos("8", reglas);
            MenuGastos.Visible = NUsuarios.VerificarPermisos("10", reglas);
            movimientosToolStripMenuItem.Visible = NUsuarios.VerificarPermisos("11", reglas);
            MenuInventario.Visible = NUsuarios.VerificarPermisos("12", reglas);
            usuariosToolStripMenuItem.Visible = NUsuarios.VerificarPermisos("13", reglas);
            tiposDeUsuariosToolStripMenuItem.Visible = NUsuarios.VerificarPermisos("13", reglas);
            permisosToolStripMenuItem.Visible = NUsuarios.VerificarPermisos("13", reglas);
            rRHHToolStripMenuItem.Visible = NUsuarios.VerificarPermisos("14", reglas);*/




            this.CargarImagen();
        }

        private void ValidarPermisosReglas(ToolStripMenuItem pTool) 
        {
            //Inicialmente se deshabilita todos los campos
            foreach (ToolStripMenuItem item in pTool.DropDownItems)
                item.Enabled = false;

            try
            {
                //Aqui se verificar que tenga los permisos para habilitar los campos
                foreach (ToolStripMenuItem item in pTool.DropDownItems)
                {
                    foreach (var regla in reglas)
                    {
                        if (Convert.ToInt32(regla) == Convert.ToInt32(item.Tag))
                        {
                            item.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }
            
        
        }

        private void unidadDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUnidadMedida frm = FrmUnidadMedida.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMarca frm = FrmMarca.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void tipoDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoProducto frm = FrmTipoProducto.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void tipoDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoServicio frm = FrmTipoServicio.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void servicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmServicio frm = FrmServicio._GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompra frm = FrmCompra.GetInstancia();
            frm.MdiParent = this;
            frm.usuario = usuario;
            frm.nombre = nombre;
            frm.apellido = apellido;
            frm.Show();
            frm.BringToFront();
        }

        private void egresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFacturaVenta frm= FrmFacturaVenta.GetInstancia();
            frm.MdiParent = this;
            frm.AutoSize = true;
            frm.Dock = DockStyle.Fill;
            frm.idUsuario = Convert.ToInt32(id);
            frm.usuario = usuario;
            frm.nombre = nombre;
            frm.apellido = apellido;
            frm.Show();
            frm.BringToFront();
        }

        private void ajustesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAjusteStock frm = FrmAjusteStock.GetInstancia();
            frm.MdiParent = this;
            frm.user = usuario;
            frm.nombre = nombre;
            frm.apellido = apellido;
            frm.Show();
            frm.BringToFront();
        }

        private void presentacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPresentacion frm = FrmPresentacion.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void cuentasPorPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCuentaPorPagar frm = FrmCuentaPorPagar.GetInstancia();
            frm.MdiParent = this;
            frm.id =Convert.ToInt32(id);
            frm.usuario = usuario;
            frm.nombre = nombre;
            frm.apellido = apellido;
            frm.Show();
            frm.BringToFront();
        }

        private void ordenDeTrabajoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrdenTrabajo frm = FrmOrdenTrabajo.GetInstancia();
            frm.MdiParent = this;
            frm.id = Convert.ToInt32(id);
            frm.usuario = usuario;
            frm.nombre = nombre;
            frm.apellido = apellido;
            frm.acceso = acceso;
            frm.Show();
            frm.BringToFront();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario frm = FrmUsuario.GetInstancia();
            frm.MdiParent = this;
            frm.idUsuario = id;
            frm.usuario = usuario;
            frm.nombre = nombre;
            frm.apellido = apellido;
            frm.acceso = acceso;
            frm.Show();
            frm.BringToFront();
        }

        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmCliente frm = FrmCliente.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void tipoDeAjusteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoAjuste frm = FrmTipoAjuste.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void movimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMovimiento frm= FrmMovimiento.GetInstancia();
            frm.MdiParent= this;
            frm.Show();
            frm.BringToFront();
        }

        private void tipoDeGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGastos frm = FrmGastos.GetInstancia();
            frm.MdiParent = this;
            frm.usuario = usuario;
            frm.id = id;
            frm.nombre = nombre;
            frm.apellido = apellido;          
            frm.Show();
            frm.BringToFront();
         
        }

        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImportarPersonaExcel frm = FrmImportarPersonaExcel.GetInstancia();
            frm.MdiParent=this;
            frm.Show();
        }

        private void backupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Backup_BD frm = Backup_BD.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompra frm = FrmCompra.GetInstancia();
            frm.MdiParent = this;
            frm.id = id;
            frm.usuario = usuario;
            frm.nombre = nombre;
            frm.apellido = apellido;
            frm.acceso = acceso; 
            frm.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFacturaVenta frm = FrmFacturaVenta.GetInstancia();
            frm.MdiParent = this;
            frm.idUsuario = Convert.ToInt32(id);
            frm.usuario = usuario;
            frm.nombre = nombre;
            frm.apellido = apellido;
            frm.acceso = acceso; 
            frm.Show();
            frm.BringToFront();
        }

        private void ventasPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaVenta frm = FrmConsultaVenta.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            
        }

        private void comprasPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaCompra frm = FrmConsultaCompra.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void libroVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLibroVentas frm = FrmLibroVentas.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void libroComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLibroCompra frm = FrmLibroCompra.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void productosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmProductosMasVendidos frm = FrmProductosMasVendidos.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void retencionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInformeRetencion frm = FrmInformeRetencion.GetInstancia();
            frm.MdiParent= this;
            frm.Show();
        }

        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInformeMovimiento frm = new FrmInformeMovimiento();
            frm.MdiParent = this;
            frm.Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FrmCompra frm = FrmCompra.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ciudadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCiudad frm = FrmCiudad.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void aperturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCaja frm = FrmCaja.GetInstancia();
            frm.id = id;
            frm.usuario = usuario;
            frm.nombre = nombre;
            frm.apellido = apellido;
            frm.MdiParent = this;
            frm.Show();
        }

        private void cierreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCierreCaja frm = FrmCierreCaja.GetInstancia();
            frm.id = id;
            frm.usuario = usuario;
            frm.acceso = acceso;
            frm.nombre = nombre;
            frm.apellido = apellido;
            frm.MdiParent = this;
            frm.Show();
        }

        private void cuentasPorCobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCuentaPorCobrar frm = FrmCuentaPorCobrar.GetInstancia();
            frm.id =Convert.ToInt32(id);
            frm.usuario = usuario;
            frm.acceso = acceso;
            frm.nombre = nombre;
            frm.apellido = apellido;
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRoles frm = FrmRoles.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reglasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRegla frm = FrmRegla.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoUsuario_Regla frm = FrmTipoUsuario_Regla.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void descuentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDescuento frm = FrmDescuento.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void procesosAbiertosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProceso frm = FrmProceso.GetInstancia();
            frm.id = Convert.ToInt32(id);
            frm.MdiParent = this;
            frm.Show();
        }

        private void empleadoServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario_Servicio frm = FrmUsuario_Servicio.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void numeracionFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMantenimientoTimbrado frm = FrmMantenimientoTimbrado.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void reportePorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInformeCaja frm = FrmInformeCaja.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        

        private void recordatoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRecordatorio frm = FrmRecordatorio.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void listadoCuentaPorCobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInformeDeudaCliente frm = new FrmInformeDeudaCliente();
            frm.Show();
        }

        private void empresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpresa frm = FrmEmpresa.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void resumenCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaCaja frm = FrmConsultaCaja.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void importarTXTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImportarPersonaTexto frm = FrmImportarPersonaTexto.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin frm = FrmLogin.GetInstancia();
            frm.Show();
            frm.BringToFront();
        }

        private void proveedoresToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmProveedor frm = FrmProveedor.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }

        private void eliminarArqueoCajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEliminarArqueo frm = FrmEliminarArqueo.GetInstancia();
            frm.id = id;
            frm.usuario = usuario;
            frm.nombre = nombre;
            frm.apellido = apellido;
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
