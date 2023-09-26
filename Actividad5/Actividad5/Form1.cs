using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad5
{
    public partial class Form1 : Form
    {
        private class Paciente
        {
            public int Codigo { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public Paciente Siguiente { get; set; }
            public Paciente Anterior { get; set; }
        }

        private Paciente cabeza;
        private Paciente cola;

        public Form1()
        {
            InitializeComponent();
        }

        private void RegistrarPaciente()
        {
            int codigo;
            if (!int.TryParse(txtCodigo.Text, out codigo))
            {
                MessageBox.Show("Ingrese un codigo valido.");
                return;
            }

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;

            Paciente nuevoPaciente = new Paciente
            {
                Codigo = codigo,
                Nombre = nombre,
                Apellido = apellido,
                Direccion = direccion,
                Telefono = telefono
            };

            if (cabeza == null) 
            {
                cabeza = nuevoPaciente;
                cola = nuevoPaciente;
            }
            else
            {
                cola.Siguiente = nuevoPaciente;
                nuevoPaciente.Anterior = cola;
                cola = nuevoPaciente;
            }

            LimpiarCampos();
            ActualizarListaPacientes();
        }

        private void EliminarPaciente()
        {
            int codigoEliminar;
            if (!int.TryParse(txtCodigo.Text, out codigoEliminar))
            {
                MessageBox.Show("Ingrese el codigo de paciente para eliminarlo.");
                return;
            }

            Paciente pacienteAEliminar = BuscarPaciente(codigoEliminar);

            if (pacienteAEliminar != null)
            {
                if (pacienteAEliminar.Anterior != null)
                {
                    pacienteAEliminar.Anterior.Siguiente = pacienteAEliminar.Siguiente;
                }
                else
                {
                    cabeza = pacienteAEliminar.Siguiente;
                }

                if (pacienteAEliminar.Siguiente != null)
                {
                    pacienteAEliminar.Siguiente.Anterior = pacienteAEliminar.Anterior;
                }
                else
                {
                    cola = pacienteAEliminar.Anterior;
                }

                LimpiarCampos();
                ActualizarListaPacientes();
            }
            else
            {
                MessageBox.Show("No se encontro un paciente con ese codigo.");
            }
        }

        private void ActualizarPaciente()
        {
            int codigo;
            if (!int.TryParse(txtCodigo.Text, out codigo))
            {
                MessageBox.Show("Ingrese el codigo de paciente para actualizarlo");
                return;
            }

            Paciente pacienteAActualizar = BuscarPaciente(codigo); 

            if (pacienteAActualizar != null)
            {
                pacienteAActualizar.Nombre = txtNombre.Text;
                pacienteAActualizar.Apellido = txtApellido.Text;
                pacienteAActualizar.Direccion = txtDireccion.Text;
                pacienteAActualizar.Telefono = txtTelefono.Text;

                LimpiarCampos();
                ActualizarListaPacientes();
            }
            else
            {
                MessageBox.Show("No se encontro un paciente con ese codigo.");
            }
        }

        private Paciente BuscarPaciente(int codigo)
        {
            Paciente pacienteActual = cabeza;

            while (pacienteActual != null)
            {
                if (pacienteActual.Codigo == codigo)
                {
                    return pacienteActual;
                }

                pacienteActual = pacienteActual.Siguiente;
            }

            return null; // No se encontró el paciente
        }

        private void ActualizarListaPacientes() 
        {
            lstPacientes.Items.Clear();

            Paciente pacienteActual = cabeza;

            while (pacienteActual != null)
            {
                lstPacientes.Items.Add($"{pacienteActual.Codigo} - {pacienteActual.Nombre} {pacienteActual.Apellido} - {pacienteActual.Direccion} - {pacienteActual.Telefono}");
                pacienteActual = pacienteActual.Siguiente;
            }
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarPaciente();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarPaciente();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarPaciente();
        }

    }
}
