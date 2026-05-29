using Presentation.Utilidades;
using Presentation.Utilidades.Objeto;
using Presentation.ViewModels;
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
    public partial class frmUsuario : Form
    {
        private readonly IRolServices _rolServices;
        private readonly IUsuarioServices _usuarioServices;
        public frmUsuario(IRolServices rolServices, IUsuarioServices usuarioServices)
        {
            InitializeComponent();
            _rolServices = rolServices;
            _usuarioServices = usuarioServices;
        }

        private async void frmUsuario_Load(object sender, EventArgs e)
        {
            dgvUsuario.ImplementarConfigurationModerno("🖋️");
            dgvUsuario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            await MostrarUsuario();
            var listaRol = await _rolServices.Lista();
            var items = listaRol.Select(item => new OpcionCombo { Texto = item.nombre, Valor = item.idRol }).ToArray();
            var items_sexo = new List<OpcionCombo>
            {
                new OpcionCombo { Texto = "Femenino", Valor = 1 },
                new OpcionCombo { Texto = "Masculino", Valor = 0 }
            };
            cbbRolCrear.insertarItems(items);
            cbbRolEditar.insertarItems(items);
            cbbSexo.insertarItems(items_sexo.ToArray());
            cbbSexoEditar.insertarItems(items_sexo.ToArray());
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

        private async Task MostrarUsuario(string buscar = "")
        {
            var lista = await _usuarioServices.Lista();
            var listaVM = lista.Select(item => new UsuarioVM
            {
                idUsuario = item.idUsuario,
                idRol = item.RefRol.idRol,
                nombre_rol = item.RefRol.nombre,
                nombre_completo = item.nombre_completo,
                correo = item.correo,
                sexo = item.sexo,
                sexo2 = item.sexo == 1 ? "Femeino" : "Masculino",
                activo = item.activo
            }).ToList();
            dgvUsuario.DataSource = listaVM;
            dgvUsuario.Columns["idUsuario"].Visible = false;
            dgvUsuario.Columns["idRol"].Visible = false;
            dgvUsuario.Columns["sexo"].Visible = false;
            dgvUsuario.Columns["nombre_completo"].HeaderText = "Nombre";
            dgvUsuario.Columns["nombre_rol"].HeaderText = "Rol";
            dgvUsuario.Columns["sexo2"].HeaderText = "Sexo";
        }

        private void btnCrearVer_Click(object sender, EventArgs e)
        {
            MostrarTab(tabCrear.Name);
        }

        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MostrarTab(tabVer.Name);
        }

        private async void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("El nombre y apellido ya existen");
                return;
            }
            if (txtCorreo.Text.Trim() == "")
            {
                MessageBox.Show("El correo ya está en uso");
                return;
            }

            var objeto = new Usuario
            {
                RefRol = new Rol { idRol = ((OpcionCombo)cbbRolCrear.SelectedItem!).Valor },
                nombre_completo = txtNombre.Text.Trim(),
                correo = txtCorreo.Text.Trim(),
                sexo = 1
            };
            var respuesta = await _usuarioServices.Crear(objeto);
            if (respuesta != "")
            {
                MessageBox.Show(respuesta);
                return;
            }
            else
            {
                await MostrarUsuario();
                MostrarTab(tabVer.Name);
            }
        }

        private void layoutVer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvUsuario.Columns[e.ColumnIndex].Name == "ColumnaAccion")
            {
                var usuarioSeleccionado = (UsuarioVM)dgvUsuario.CurrentRow.DataBoundItem;
                cbActivo.Checked = usuarioSeleccionado.activo;
                txtNombreCompletoEditar.Text = usuarioSeleccionado.nombre_completo.ToString();
                txtCorreoEditar.Text = usuarioSeleccionado.correo.ToString();
                cbbSexo.EstablecerValor(usuarioSeleccionado.sexo);
                cbbRolEditar.EstablecerValor(usuarioSeleccionado.idRol);

                MostrarTab(tabEditar.Name);
                txtNombreCompletoEditar.Select();
            }
        }

        private async void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (txtNombreCompletoEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar un nombre completo");
                return;
            }
            if (txtCorreoEditar.Text.Trim() == "")
            {
                MessageBox.Show("Debe Ingresar un Correo electrónico");
                return;
            }

            var usuarioSeleccionado = (UsuarioVM)dgvUsuario.CurrentRow.DataBoundItem;
            var objeto = new Usuario
            {
                idUsuario = usuarioSeleccionado.idUsuario,
                RefRol = new Rol { idRol = ((OpcionCombo)cbbRolEditar.SelectedItem!).Valor },
                nombre_completo = txtNombreCompletoEditar.Text.Trim(),
                correo = txtCorreoEditar.Text.Trim(),
                sexo = ((OpcionCombo)cbbSexoEditar.SelectedItem!).Valor,
                activo = cbActivo.Checked
            };
            var respuesta = await _usuarioServices.Editar(objeto);
            if (respuesta != "")
            {
                MessageBox.Show(respuesta);
                return;
            }
            else
            {
                await MostrarUsuario();
                MostrarTab(tabVer.Name);
            }
        }

        private void btnCancelarEditar_Click(object sender, EventArgs e)
        {
            MostrarTab(tabVer.Name);
        }

        private void cbActivo_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
