using Microsoft.Extensions.DependencyInjection;
using Presentation.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Formularios
{
    public partial class Layout : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public Layout(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }
        private void MostrarFormulario<TForm>() where TForm : Form
        {
            if (panelMain.Controls.Count > 0) panelMain.Controls[0].Dispose();

            var newForm = _serviceProvider.GetRequiredService<TForm>();

            newForm.TopLevel = false;
            newForm.TopMost = false;
            panelMain.Controls.Add(newForm);
            newForm.Show();
        }
        private void Layout_Load(object sender, EventArgs e)
        {
            msMenu.Renderer = new CustomToolStripRender();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximized_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            WindowState |= FormWindowState.Minimized;
        }

        private void mnUsuario_Click(object sender, EventArgs e)
        {
            MostrarFormulario<frmUsuario>();
        }

        private void mnProducto_Click(object sender, EventArgs e)
        {
            MostrarFormulario<frmProducto>();
        }

        private void mnVenta_Click(object sender, EventArgs e)
        {
            MostrarFormulario<frmVenta>();
        }
    }
}
