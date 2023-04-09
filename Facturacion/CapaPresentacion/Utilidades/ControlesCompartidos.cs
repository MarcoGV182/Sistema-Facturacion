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

        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }


        public static void FormatoNumero(object sender)
        {
            // Obtener la referencia al control TextBox
            TextBox textBox = sender as TextBox;

            // Obtener el valor numérico del texto ingresado
            if (double.TryParse(textBox.Text, out double number))
            {
                // Formatear el número con separadores de miles
                string formattedNumber = number.ToString("N0");

                // Actualizar el texto en el control TextBox
                textBox.Text = formattedNumber;

                // Mover el cursor al final del texto
                textBox.SelectionStart = formattedNumber.Length;
            }
        }
    }
}
