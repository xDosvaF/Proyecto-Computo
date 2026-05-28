using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Utilidades
{
    public static class CustomDataGridView 
    {
        public static void ImplementarConfigurationModerno(this Guna2DataGridView datagrid, string textoEnBoton = "")
        {
            // Fondos — capas de gris muy suave
            Color macBg = Color.FromArgb(232, 232, 237); // ventana exterior
            Color macSurface = Color.FromArgb(245, 245, 247); // toolbar / form bg
            Color macCard = Color.FromArgb(255, 255, 255); // tabla / cards
            Color macHeader = Color.FromArgb(245, 245, 247); // cabecera de columnas
            Color macBorder = Color.FromArgb(224, 224, 229); // líneas divisoras

            // Texto
            Color macTextPrimary = Color.FromArgb(28, 28, 30);  // texto principal
            Color macTextSecondary = Color.FromArgb(99, 99, 102);  // texto muted
            Color macTextTertiary = Color.FromArgb(142, 142, 147); // placeholders / labels

            // Acento Apple Blue
            Color macBlue = Color.FromArgb(0, 113, 227);
            Color macBlueLight = Color.FromArgb(232, 240, 253); // fila seleccionada

            // Estados
            Color macGreen = Color.FromArgb(52, 199, 89);
            Color macOrange = Color.FromArgb(255, 159, 10);

            datagrid.BackgroundColor = macCard;
            datagrid.GridColor = Color.FromArgb(240, 240, 242);
            datagrid.ThemeStyle.HeaderStyle.BackColor = macHeader;
            datagrid.ThemeStyle.HeaderStyle.ForeColor = macTextTertiary;
            datagrid.ThemeStyle.HeaderStyle.Font = new Font("SF Pro Text", 9F);
            datagrid.ThemeStyle.RowsStyle.Height = 38;
            datagrid.ThemeStyle.RowsStyle.BackColor = macCard;
            datagrid.ThemeStyle.RowsStyle.ForeColor = macTextPrimary;
            datagrid.ThemeStyle.RowsStyle.SelectionBackColor = macBlueLight;
            datagrid.ThemeStyle.RowsStyle.SelectionForeColor = macTextPrimary;
            datagrid.ThemeStyle.RowsStyle.Font = new Font("SF Pro Text", 10F);

            if (textoEnBoton != "")
            {
                var btnEditarColumn = new DataGridViewButtonColumn();
                btnEditarColumn.Text = textoEnBoton;
                btnEditarColumn.Name = "ColumnaAccion";
                btnEditarColumn.HeaderText = "";
                btnEditarColumn.UseColumnTextForButtonValue = true;
                btnEditarColumn.Width = 50;
                btnEditarColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                btnEditarColumn.DefaultCellStyle.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Bold);

                // Botón de acción estilo macOS
                btnEditarColumn.DefaultCellStyle.BackColor = macCard;
                btnEditarColumn.DefaultCellStyle.ForeColor = macTextPrimary;
                btnEditarColumn.DefaultCellStyle.SelectionBackColor = macBlueLight;
                btnEditarColumn.FlatStyle = FlatStyle.Flat;


                btnEditarColumn.FlatStyle = FlatStyle.Flat;


                datagrid.Columns.Add(btnEditarColumn);
            }
        }
    }
}
