using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test.Utils
{
    public class DataGridViewUtil
    {
        private static void AddButtonColumn(
            DataGridView gridView,
            string columnName,
            string headerText,
            string buttonText,
            Color? backgroundColor = null,
            Color? textColor = null)
        {
            if (gridView.Columns[columnName] == null)
            {
                var buttonColumn = new DataGridViewButtonColumn
                {
                    Name = columnName,
                    HeaderText = headerText,
                    Text = buttonText,
                    UseColumnTextForButtonValue = true
                };

                gridView.Columns.Add(buttonColumn);

                if (backgroundColor.HasValue || textColor.HasValue)
                {
                    gridView.CellFormatting += (sender, e) =>
                    {
                        if (gridView.Columns[e.ColumnIndex].Name == columnName)
                        {
                            e.CellStyle.BackColor = backgroundColor ?? e.CellStyle.BackColor;
                            e.CellStyle.ForeColor = textColor ?? e.CellStyle.ForeColor;
                            e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        }
                    };
                }
            }
        }
        public static void AddActionButtons(DataGridView gridView)
        {
            AddButtonColumn(gridView, "AddColumn", "Adicionar", "Adicionar");
            AddButtonColumn(gridView, "RemoveColumn", "Remover", "Remover");
        }
        public static void AddActionAddButtons(DataGridView gridView)
        {
            AddButtonColumn(gridView, "AddColumn", "Adicionar", "Adicionar");
        }

        public static void AddEditAndDeleteButtons(DataGridView gridView)
        {
            AddButtonColumn(gridView, "EditColumn", "Editar", "Editar", Color.LightBlue, Color.Black);
            AddButtonColumn(gridView, "DeleteColumn", "Deletar", "Deletar", Color.IndianRed, Color.White);
        }
    }
}
