using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EjercicioLista1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        private bool CamposVacios()
        {
            return string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                   string.IsNullOrWhiteSpace(txtNombre.Text) ||
                   string.IsNullOrWhiteSpace(txtApellido.Text) ||
                   string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                   string.IsNullOrWhiteSpace(txtTelefono.Text);
        }

        private ListViewItem CrearItem()
        {
            var item = new ListViewItem(txtCodigo.Text);
            item.SubItems.AddRange(new[] { txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtTelefono.Text });
            return item;
        }

        private void MostrarMensaje(string mensaje, MessageBoxIcon icono = MessageBoxIcon.Information)
        {
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, icono);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (CamposVacios())
            {
                MostrarMensaje("Debe llenar todos los campos", MessageBoxIcon.Error);
            }
            else
            {
                lstPacientes.Items.Add(CrearItem());
                LimpiarCampos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (CamposVacios())
            {
                MostrarMensaje("Debe llenar todos los campos", MessageBoxIcon.Error);
            }
            else if (lstPacientes.SelectedItems.Count > 0)
            {
                int selectedIndex = lstPacientes.SelectedIndices[0];
                lstPacientes.Items[selectedIndex] = CrearItem();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstPacientes.SelectedItems.Count > 0)
            {
                lstPacientes.Items.Remove(lstPacientes.SelectedItems[0]);
            }
            else
            {
                MostrarMensaje("Debe seleccionar un elemento", MessageBoxIcon.Error);
            }
        }

        private void btnAgregarSeleccionado_Click(object sender, EventArgs e)
        {
            if (CamposVacios())
            {
                MostrarMensaje("Debe llenar todos los campos", MessageBoxIcon.Error);
            }
            else if (lstPacientes.SelectedItems.Count > 0)
            {
                int selectedIndex = lstPacientes.SelectedIndices[0];
                lstPacientes.Items.Insert(selectedIndex + 1, CrearItem());
                LimpiarCampos();
            }
            else
            {
                lstPacientes.Items.Add(CrearItem());
                LimpiarCampos();
            }
        }
    }
}
