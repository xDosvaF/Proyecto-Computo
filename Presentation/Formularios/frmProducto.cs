using Presentation.Utilidades;
using Presentation.Utilidades.Objeto;
using Repository.Entities;
using Services.Implementation;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Formularios
{
    public partial class frmProducto : Form
    {
        private readonly ICategoriaServices _categoriaServices;
        private readonly IProductoServices _productoServices;

        public frmProducto(ICategoriaServices categoriaServices, IProductoServices productoServices)
        {
            InitializeComponent();
            _categoriaServices = categoriaServices;
            _productoServices = productoServices;
        }

        private async void frmProducto_Load(object sender, EventArgs e)
        {
            var listaRol = await _categoriaServices.Lista();
            var items = listaRol.Select(item => new OpcionCombo { Texto = item.nombre, Valor = item.idCategoria }).ToArray();
            cbbCategoriaCrear.insertarItems(items);
        }

        public void MostrarTab(string tabName)
        {
            var TabsMenu = new TabPage[] { tabCrear, tabVer, tabEditar };

            foreach (var tab in TabsMenu)
            {
                if (tab.Name != tabName)
                {
                    tab.Parent = null;
                }
                else
                {
                    tab.Parent = tabControlMain;
                }
            }
        }

        private void btnCancelarCrear_Click(object sender, EventArgs e)
        {
            MostrarTab(tabVer.Name);
        }

        private void btnCrearVer_Click(object sender, EventArgs e)
        {
            MostrarTab(tabCrear.Name);
        }

        private async void btnCrearProducto_Click(object sender, EventArgs e)
        {
            if (txtNombreCrear.Text.Trim() == "")
            {
                MessageBox.Show("El nombre y apellido ya existen");
                return;
            }

            var objeto = new Producto
            {
                RefCategoria = new Categoria { idCategoria = ((OpcionCombo)cbbCategoriaCrear.SelectedItem!).Valor },
                nombre = txtNombreCrear.Text.Trim(),
                descripcion = txtDescripcionCrear.Text.Trim(),
                precio = numPrecioCrear.Value
            };
            var respuesta = await _productoServices.Crear(objeto);
            if (respuesta != "")
            {
                MessageBox.Show(respuesta);
                return;
            }
            else
            {
                MostrarTab(tabVer.Name);
            }
        }
    }
}
