using System;
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
    public partial class FrmCargandoForm : Form
    {
        //public Action Worker { get; set; }
        public bool Activo;
        public FrmCargandoForm()
        {
            InitializeComponent();
        }

       private void FrmCargandoForm_Load(object sender, EventArgs e) 
       {
            while (Activo)
            {
                // Esperar a que Activo sea false
                Application.DoEvents();
            }

            // Cerrar el formulario de carga
            this.Close();
        }
    }
}
