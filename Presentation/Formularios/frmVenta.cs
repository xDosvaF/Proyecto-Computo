using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using Presentation.Utilidades;
using Presentation.ViewModels;
using Repository.Data;
using Repository.Entities;
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
    public partial class frmVenta : Form
    {
        private readonly IProductoServices _productoServices;
        private readonly IServiceProvider _serviceProvider;
        private readonly IVentaServices _ventaServices;
        private readonly IDetalleVentaServices _detalleVentaServices;
        private BindingList<DetalleVentaVM> _detalleVenta = new BindingList<DetalleVentaVM>();

        public frmVenta(IProductoServices productoServices, IServiceProvider serviceProvider, IVentaServices ventaServices, IDetalleVentaServices detalleVentaServices)
        {
            InitializeComponent();
            _productoServices = productoServices;
            _serviceProvider = serviceProvider;
            _ventaServices = ventaServices;
            _detalleVentaServices = detalleVentaServices;
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            dgvDetalleVenta.ImplementarConfigurationModerno("Eliminar");
            dgvDetalleVenta.DataSource = _detalleVenta;
            dgvDetalleVenta.Columns["idProducto"].Visible = false;
            dgvDetalleVenta.Columns["Producto"].FillWeight = 350;
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }

        private async Task AgregarProducto(string nombre)
        {
            var producto = await _productoServices.Obtener(nombre);
            if (producto.idProducto == 0)
            {
                txtNombreProducto.BackColor = Color.FromArgb(255, 227, 227);
                return;
            }
            txtNombreProducto.BackColor = SystemColors.Window;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(producto.descripcion);
            sb.AppendLine("Categoria: " + producto.RefCategoria.nombre);
            sb.AppendLine("Precio: Q" + producto.precio.ToString("0.00"));
            sb.AppendLine("Cantidad disponibles: " + producto.stock.ToString());

            string cantidadString = Interaction.InputBox(sb.ToString(), "Producto", "1");
            if (string.IsNullOrEmpty(cantidadString)) return;

            int cantidad;

            if (!int.TryParse(cantidadString, out cantidad))
            {
                MessageBox.Show("El valor ingresado NO es un numero");
                return;
            }
            if (cantidad > producto.stock)
            {
                MessageBox.Show("La cantidad ingresada no puede exceder al stock");
                return;
            }

            var encontrado = _detalleVenta.FirstOrDefault(x => x.idProducto == producto.idProducto);

            if (encontrado == null)
            {
                decimal total = cantidad * producto.precio;

                _detalleVenta.Add(new DetalleVentaVM
                {
                    idProducto = producto.idProducto,
                    producto = producto.nombre,
                    precio = producto.precio,
                    cantidad = cantidad,
                    Total = Convert.ToDecimal(total.ToString("0.00"))
                });
            }
            else
            {
                int index = _detalleVenta.IndexOf(encontrado);
                int cantidadTotal = encontrado.cantidad + cantidad;
                decimal total = cantidadTotal * producto.precio;

                encontrado.cantidad = cantidadTotal;
                encontrado.Total = Convert.ToDecimal(total.ToString("0.00"));
                _detalleVenta[index] = encontrado;
            }

            decimal Total = _detalleVenta.Sum(x => x.Total);
            txtNombreProducto.Text = "";
        }

        private async void txtNombreProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                await AgregarProducto(txtNombreProducto.Text.Trim());
            }
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            var _fromBuscarProducto = _serviceProvider.GetRequiredService<frmBuscarProducto>();
            var resultado = _fromBuscarProducto.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                var productoSeleccionado = _fromBuscarProducto._productoSeleccionado;
                txtNombreProducto.Text = productoSeleccionado.nombre;
                await AgregarProducto(productoSeleccionado.nombre);
            }
        }

        private void dgvDetalleVenta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleVenta.Columns[e.ColumnIndex].Name == "ColumnaAccion")
            {
                var filaSeleccionada = (DetalleVentaVM)dgvDetalleVenta.CurrentRow.DataBoundItem;

                var index = _detalleVenta.IndexOf(filaSeleccionada);
                _detalleVenta.RemoveAt(index);

                decimal Total = _detalleVenta.Sum(x => x.Total);
            }
        }

        private async void btnCrearProducto_Click(object sender, EventArgs e)
        {
            if (_detalleVenta.Count == 0)
            {
                MessageBox.Show("No hay productos");
                return;
            }

            decimal tempTotal = _detalleVenta.Sum(x => x.Total);
            var precioTotal = Convert.ToDecimal(tempTotal.ToString("0.00"));

            var pago = txtPago.Text.Trim() == "" ? precioTotal : Convert.ToDecimal(txtPago.Text.Trim());
            var cambio = txtCambio.Text.Trim() == "" ? 0 : Convert.ToDecimal(txtCambio.Text.Trim());

            var venta = new Venta
            {
                UsuarioRegistro = new Usuario { idUsuario = 1 },
                nombre_cliente = txtNombreCliente.Text.Trim(),
                pago_total = precioTotal,
                pago = pago,
                cambio = cambio,
                Detalles = _detalleVenta.Select(x => new DetalleVenta
                {
                    RefProducto = new Producto { idProducto = x.idProducto },
                    cantidad = x.cantidad,
                    precio_total = (int)x.Total
                }).ToList()
            };

            string respuesta = await _ventaServices.Guardar(venta);

            if (respuesta == "OK")
            {
                MessageBox.Show("Venta registrada correctamente");
                _detalleVenta.Clear();
            }
            else
            {
                MessageBox.Show(respuesta);
            }
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {

            var listaVM = _detalleVenta.Select(item => new DetalleVentaVM
            {

                producto = item.producto,
                nombre_cliente = txtNombreCliente.Text.Trim() == "" ? "Consumidor Final" : txtNombreCliente.Text.Trim(), 
                precio = item.precio,
                cantidad = item.cantidad,
                Total = item.Total
            }).ToList();

            if (listaVM.Count == 0)
            {
                MessageBox.Show("No hay productos cargados en la venta actual para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string titulo = "Comprobante de Venta Actual";
            string[] cabeceras = { "Cliente", "Producto", "Precio", "Cant.", "Total" };
            float[] anchos = { 25f, 35f, 15f, 10f, 15f };

            ReporteGenerator.GenerarReportePdf(listaVM, titulo, cabeceras, anchos, (item, tabla, fuente) =>
            {
                tabla.AddCell(new PdfPCell(new Phrase(item.nombre_cliente, fuente)));
                tabla.AddCell(new PdfPCell(new Phrase(item.producto, fuente)));

                PdfPCell cPrecio = new PdfPCell(new Phrase($"Q {item.precio:N2}", fuente)) { HorizontalAlignment = Element.ALIGN_RIGHT };
                tabla.AddCell(cPrecio);

                PdfPCell cCantidad = new PdfPCell(new Phrase(item.cantidad.ToString(), fuente)) { HorizontalAlignment = Element.ALIGN_CENTER };
                tabla.AddCell(cCantidad);

                PdfPCell cTotal = new PdfPCell(new Phrase($"Q {item.Total:N2}", fuente)) { HorizontalAlignment = Element.ALIGN_RIGHT };
                tabla.AddCell(cTotal);
            });
        }
    }
}
