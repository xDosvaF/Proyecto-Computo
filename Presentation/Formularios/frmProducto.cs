using Presentation.Utilidades;
using Presentation.Utilidades.Objeto;
using Presentation.ViewModels;
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

        private async Task MostrarProducto(string buscar = "")
        {
            var lista = await _productoServices.Lista();
            var listaVM = lista.Select(item => new ProductoVM
            {
                idProducto = item.idProducto,
                idCategoria = item.RefCategoria.idCategoria,
                nombre_categoria = item.RefCategoria.nombre,
                nombre = item.nombre,
                descripcion = item.descripcion,
                precio = item.precio,
                activo = item.activo,

            }).ToList();
            dgvProducto.DataSource = listaVM;
            dgvProducto.Columns["idCategoria"].Visible = false;
            dgvProducto.Columns["idProducto"].Visible = false;
            dgvProducto.Columns["activo"].Visible = false;
            dgvProducto.Columns["nombre_categoria"].HeaderText = "Categoria";

        }


        private async void frmProducto_Load(object sender, EventArgs e)
        {
            dgvProducto.ImplementarConfigurationModerno("🖋️");
            await MostrarProducto();
            var listaRol = await _categoriaServices.Lista();
            var items = listaRol.Select(item => new OpcionCombo { Texto = item.nombre, Valor = item.idCategoria }).ToArray();
            cbbCategoriaCrear.insertarItems(items);
            cbbCategoriaEditar.insertarItems(items);
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

        private void btnCrearVer_Click_1(object sender, EventArgs e)
        {
            MostrarTab(tabCrear.Name);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MostrarTab(tabVer.Name);
        }

        private async void btnCrearProducto_Click_1(object sender, EventArgs e)
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
                await MostrarProducto();
                MostrarTab(tabVer.Name);
            }
        }

        private void dgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducto.Columns[e.ColumnIndex].Name == "ColumnaAccion")
            {
                var usuarioSeleccionado = (ProductoVM)dgvProducto.CurrentRow.DataBoundItem;
                cbActivo.Checked = usuarioSeleccionado.activo;
                txtNombreEditar.Text = usuarioSeleccionado.nombre.ToString();
                txtDescripcionEditar.Text = usuarioSeleccionado.descripcion.ToString();
                numPrecioEditar.Value = usuarioSeleccionado.precio;
                cbbCategoriaEditar.EstablecerValor(usuarioSeleccionado.idCategoria);

                MostrarTab(tabEditar.Name);
                txtNombreEditar.Select();
            }
        }

        private async void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (txtNombreEditar.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese un Nombre");
                return;
            }

            var productoSeleccionado = (ProductoVM)dgvProducto.CurrentRow.DataBoundItem;
            var objeto = new Producto
            {
                idProducto = productoSeleccionado.idProducto,
                RefCategoria = new Categoria { idCategoria = ((OpcionCombo)cbbCategoriaCrear.SelectedItem!).Valor },
                nombre = txtNombreEditar.Text.Trim(),
                descripcion = txtDescripcionEditar.Text.Trim(),
                precio = numPrecioEditar.Value,
                activo = cbActivo.Checked
            };
            var respuesta = await _productoServices.Editar(objeto);
            if (respuesta != "")
            {
                MessageBox.Show(respuesta);
                return;
            }
            else
            {
                await MostrarProducto();
                MostrarTab(tabVer.Name);
            }
        }

        private void btnCancelarEditar_Click(object sender, EventArgs e)
        {
            MostrarTab(tabVer.Name);
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            var lista = await _productoServices.Lista();

            // 2. Mapearlos a la lista de ViewModels (tal cual lo haces en tu método MostrarProducto)
            var listaVM = lista.Select(item => new ProductoVM
            {
                nombre_categoria = item.RefCategoria.nombre,
                nombre = item.nombre,
                descripcion = item.descripcion,
                precio = item.precio
            }).ToList();

            if (listaVM.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Preguntar dónde guardar el archivo
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivos PDF (*.pdf)|*.pdf";
            sfd.FileName = "Reporte_de_Productos.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // 4. Llamar al método simplificado
                ReporteGenerator.GenerarPdfProductos(listaVM, sfd.FileName);

                MessageBox.Show("¡Reporte PDF creado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
