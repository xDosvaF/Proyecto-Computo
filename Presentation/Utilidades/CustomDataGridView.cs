using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Utilidades
{
    public static class CustomDataGridView 
    {

        public static void ImplementarConfigurationModerno(this Guna2DataGridView datagrid, string textoEnBoton="")
        {
            datagrid.AllowUserToAddRows = false;
            datagrid.AllowUserToDeleteRows = false;
            datagrid.AllowUserToResizeColumns = true;
            datagrid.AllowUserToResizeRows = false;
            datagrid.AllowUserToOrderColumns = false;
            datagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagrid.MultiSelect = false;
            datagrid.RowHeadersVisible = false;
            datagrid.ReadOnly = true;

            datagrid.BackgroundColor = Color.White;
            datagrid.BorderStyle = BorderStyle.None;
            datagrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            datagrid.GridColor = Color.FromArgb(238, 239, 242);
            datagrid.ThemeStyle.BackColor = Color.White;
            datagrid.ThemeStyle.GridColor = Color.FromArgb(238, 239, 242);

            datagrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagrid.ColumnHeadersHeight = 40;
            datagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            datagrid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(246, 247, 251),
                ForeColor = Color.FromArgb(140, 144, 156),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 0, 0)
            };

            datagrid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(18, 18, 18),
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                SelectionBackColor = Color.FromArgb(240, 242, 245),
                SelectionForeColor = Color.FromArgb(18, 18, 18),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 0, 0)
            };

            datagrid.RowTemplate.Height = 45;
            datagrid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.White };

            if (!string.IsNullOrEmpty(textoEnBoton))
            {
                var btnEditarColumn = new DataGridViewButtonColumn
                {
                    Text = textoEnBoton,
                    Name = "ColumnaAccion",
                    HeaderText = "Acción",
                    UseColumnTextForButtonValue = true,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells,
                    FlatStyle = FlatStyle.Flat
                };

                btnEditarColumn.DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(240, 242, 245),
                    ForeColor = Color.FromArgb(18, 18, 18),
                    SelectionBackColor = Color.FromArgb(220, 224, 230),
                    SelectionForeColor = Color.FromArgb(18, 18, 18),
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new Padding(5, 2, 5, 2)
                };

                datagrid.Columns.Add(btnEditarColumn);
            }
        }
    }
}
