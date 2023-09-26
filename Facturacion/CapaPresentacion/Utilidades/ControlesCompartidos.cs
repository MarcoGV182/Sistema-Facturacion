using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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

        public static List<T> AgregarNuevaFila<T>(List<T>Lista , string nombreCellDisplayMember, string nombreCellValueMember) where T: class
        {
            if (Lista == null || Lista.Count == 0)
                return Lista;


            // Crear una instancia de T (clase) utilizando reflection
            Type tipo = typeof(T);
            T nuevaFila = (T)Activator.CreateInstance(tipo);

            // Asignar valores a las propiedades de la nueva fila
            PropertyInfo propDisplayMember = tipo.GetProperty(nombreCellDisplayMember);
            PropertyInfo propValueMember = tipo.GetProperty(nombreCellValueMember);

            if (propDisplayMember != null && propValueMember != null)
            {
                propDisplayMember.SetValue(nuevaFila, "Seleccione", null); // Cambia "ValorDisplay" por el valor deseado
                propValueMember.SetValue(nuevaFila, 0, null);     // Cambia "ValorValue" por el valor deseado
            }
            else
            {
                throw new ArgumentException("Los nombres de propiedad proporcionados no son válidos.");
            }

            // Agregar la nueva fila a la lista
            Lista.Add(nuevaFila);

            return Lista.OrderBy(item => propValueMember.GetValue(item)).ToList(); ;
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


        public static bool ValidarDireccionCorreo(string email) 
        {
            string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(email, emailRegex))
            {
                return false;
            }

            return true;
        }


        public static string ObtenerValorAppSettings()
        {
            // Obtener el valor de la clave 'Ind_logoFondoPantalla'
            var valor = ConfigurationManager.AppSettings["Ind_logoFondoPantalla"];
            // Devolver el valor encontrado
            return valor;
        }
    }
}
