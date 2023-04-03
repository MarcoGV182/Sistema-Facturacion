using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Utilidades
{
    public partial class ControlesCompartidos : Form
    {
        public static bool MensajeConfirmacion(Form formularioActual,string mensaje)
        {
            try
            {
                if (MessageBox.Show(formularioActual, mensaje, "Sistema de Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
            return true;
        }


        public static System.Data.DataTable AgregarNuevaFila(System.Data.DataTable table, string nombreCellDisplayMember, string nombreCellValueMember)
        {
            if (table == null || table.Rows.Count == 0)
                return table;


            var newRow = table.NewRow();
            newRow[nombreCellDisplayMember] = "Seleccione";
            newRow[nombreCellValueMember] = 0;
            table.Rows.InsertAt(newRow, 0);
                       

            return table;
        }
    }
}
