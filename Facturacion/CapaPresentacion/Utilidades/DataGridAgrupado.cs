using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion.Utilidades
{
    public class Grilla : DataGridView
    {  
        public string[] GroupColumns { get; set; }

        private bool esRepetidoValorCelda(int fila, int columna)
        {
            bool exito = false;
            int c = fila - 1;
            dynamic valorCelda = this.Rows[fila].Cells[columna].Value;
            dynamic valorComparar;
            while (c > -1)
            {
                valorComparar = this.Rows[c].Cells[columna].Value;
                if (valorCelda.Equals(valorComparar))
                {
                    exito = true;
                    break;
                }
                c--;
            }
            return (exito);
        }

        private bool esColumnaCombinar(string nombreColumna)
        {
            bool exito = false;
            foreach (string columna in GroupColumns)
            {
                if (columna.Equals(nombreColumna))
                {
                    exito = true;
                    break;
                }
            }
            return (exito);
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0) return;
            string nombreColumna = this.Columns[e.ColumnIndex].Name;
            bool esCombinada = (GroupColumns != null && esColumnaCombinar(nombreColumna));
            if ((esCombinada && !esRepetidoValorCelda(e.RowIndex, e.ColumnIndex))
            || !esCombinada) e.AdvancedBorderStyle.Top = AdvancedCellBorderStyle.Top;
            else e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
        }

        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            base.OnCellFormatting(e);
            bool esNumero = (e.Value is Int16 || e.Value is Int32 || e.Value is Int64 || e.Value is int
                                          || e.Value is decimal);
            if (esNumero)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                bool esDecimal = (e.Value is decimal);
                if (esDecimal) e.CellStyle.Format = "n2";
            }
            string nombreColumna = this.Columns[e.ColumnIndex].Name;
            bool esCombinada = (GroupColumns != null && esColumnaCombinar(nombreColumna));
            if (esCombinada && esRepetidoValorCelda(e.RowIndex, e.ColumnIndex))
            {
                e.Value = string.Empty;
                e.FormattingApplied = true;
            }
        }
    }
}
