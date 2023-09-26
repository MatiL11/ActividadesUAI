using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LimpiarCampos() // Método para limpiar los campos de texto
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            txtFechaNacimiento.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        private bool CamposVacios() // Método para verificar si hay campos vacíos
        {
            return string.IsNullOrWhiteSpace(txtNombre.Text) ||
                   string.IsNullOrWhiteSpace(txtApellido.Text) ||
                   string.IsNullOrWhiteSpace(txtDNI.Text) ||
                   string.IsNullOrWhiteSpace(txtFechaNacimiento.Text) ||
                   string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                   string.IsNullOrWhiteSpace(txtTelefono.Text);
        }

        private ListViewItem CrearItem() // Método para crear un elemento de la lista
        {
            return new ListViewItem(txtNombre.Text)
            {
                SubItems =
                {
                    txtApellido.Text,
                    txtDNI.Text,
                    txtFechaNacimiento.Text,
                    txtDireccion.Text,
                    txtTelefono.Text
                }
            };
        }

        private void btnAgregar_Click(object sender, EventArgs e) // Agregar un elemento a la lista
        {
            if (CamposVacios())
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else
            {
                lstAlumnos.Items.Add(CrearItem());
                LimpiarCampos();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e) // Actualizar un elemento de la lista
        {
            if (CamposVacios())
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (lstAlumnos.SelectedItems.Count > 0)
            {
                ListViewItem newItem = CrearItem();
                int selectedIndex = lstAlumnos.SelectedIndices[0];
                lstAlumnos.Items[selectedIndex] = newItem; // Reemplaza el elemento existente
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e) // Eliminar un elemento de la lista
        {
            if (lstAlumnos.SelectedItems.Count > 0)
            {
                lstAlumnos.Items.Remove(lstAlumnos.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un elemento");
            }
        }

        private void btnAgregarDespSeleccionado_Click(object sender, EventArgs e) // Agregar un elemento despues del seleccionado
        {
            if (CamposVacios())
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (lstAlumnos.SelectedItems.Count > 0)
            {
                int selectedIndex = lstAlumnos.SelectedIndices[0];
                lstAlumnos.Items.Insert(selectedIndex + 1, CrearItem());
                LimpiarCampos();
            }
            else
            {
                lstAlumnos.Items.Add(CrearItem());
                LimpiarCampos();
            }
        }

        private void btnAgregarAntSeleccionado_Click(object sender, EventArgs e) // Agregar un elemento antes del seleccionado
        {
            if (CamposVacios())
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
            else if (lstAlumnos.SelectedItems.Count > 0)
            {
                int selectedIndex = lstAlumnos.SelectedIndices[0];
                lstAlumnos.Items.Insert(selectedIndex, CrearItem());
                LimpiarCampos();
            }
            else
            {
                lstAlumnos.Items.Add(CrearItem());
                LimpiarCampos();
            }
        }
    }
}
