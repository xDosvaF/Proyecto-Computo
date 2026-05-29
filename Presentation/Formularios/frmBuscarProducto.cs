using Presentation.Utilidades;
using Presentation.ViewModels;
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
    public partial class frmBuscarProducto : Form
    {
        private readonly ICategoriaServices _categoriaServices;
        private readonly IProductoServices _productoServices;
        public ProductoVM _productoSeleccionado { get; set; } = null!;
        public frmBuscarProducto(ICategoriaServices categoriaServices, IProductoServices productoServices)
        {
            InitializeComponent();
            _categoriaServices = categoriaServices;
            _productoServices = productoServices;
        }

        private async Task MostrarProducto(string buscar = "")
        {
            var listaProductos = await _productoServices.Lista();
            var listaVM = listaProductos
            .Where(item => item.activo == true && item.stock > 0)
            .Select(item => new ProductoVM
            {
                idProducto = item.idProducto,
                idCategoria = item.RefCategoria.idCategoria,
                nombre_categoria = item.RefCategoria.nombre,
                nombre = item.nombre,
                descripcion = item.descripcion,
                precio = item.precio,
                stock = item.stock
            }).ToList();
            dgvProducto.DataSource = listaVM;
            dgvProducto.Columns["idCategoria"].Visible = false;
            dgvProducto.Columns["idProducto"].Visible = false;
            dgvProducto.Columns["activo"].Visible = false;
            dgvProducto.Columns["nombre_categoria"].HeaderText = "Categoria";

        }

        private async void frmBuscarProducto_Load(object sender, EventArgs e)
        {
            dgvProducto.ImplementarConfigurationModerno("");
            await MostrarProducto();
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            await MostrarProducto(guna2Button1.Text.Trim());
        }

        private void dgvProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _productoSeleccionado = (ProductoVM)dgvProducto.CurrentRow.DataBoundItem;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
