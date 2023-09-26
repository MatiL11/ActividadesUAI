using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad3
{
    public partial class Form1 : Form
    {
        private class Persona
        {
            public string Nombre { get; set; }
            public int Edad { get; set; }
            public double PrecioEntrada { get; set; }
            public double PrecioFinal { get; set; }

            public Persona(string nombre, int edad, double precioEntrada)
            {
                Nombre = nombre;
                Edad = edad;
                PrecioEntrada = precioEntrada;
                PrecioFinal = precioEntrada; // Inicialmente, el precio final es igual al precio de entrada
            }
        }

        private List<Persona> listaPersonas = new List<Persona>(); // Lista de personas
        private int personaSeleccionadaIndex = +1; // Índice de la persona seleccionada en la lista
        public Form1()
        {
            InitializeComponent();
        }

        private void AgregarPersona() // Agregar una persona a la lista
        {
            if (ValidarCampos(out string nombre, out int edad))
            {
                double precioEntrada = CalcularPrecioEntrada(edad);
                Persona nuevaPersona = new Persona(nombre, edad, precioEntrada);

                ListViewItem item = new ListViewItem(nuevaPersona.Nombre);
                item.SubItems.Add(nuevaPersona.Edad.ToString());
                item.SubItems.Add($"${nuevaPersona.PrecioFinal:0.00}"); // Mostrar el precio final

                lstPersonas.Items.Add(item);

                listaPersonas.Add(nuevaPersona);

                ActualizarTotalRecaudado();
                LimpiarCampos();
            }
        }

        private void EliminarPersona() // Eliminar la persona seleccionada de la lista
        {
            if (personaSeleccionadaIndex >= 0 && personaSeleccionadaIndex < listaPersonas.Count)
            {
                listaPersonas.RemoveAt(personaSeleccionadaIndex);

                // Elimina la persona seleccionada del ListView
                if (lstPersonas.SelectedItems.Count > 0)
                {
                    lstPersonas.Items.RemoveAt(lstPersonas.SelectedIndices[0]);
                }

                ActualizarTotalRecaudado();
                LimpiarCampos();
            }
        }

        private void ActualizarPersona() // Actualizar la persona seleccionada de la lista
        {
            if (lstPersonas.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una persona de la lista.");
                return;
            }

            int personaSeleccionadaIndex = lstPersonas.SelectedIndices[0];

            if (!ValidarCampos(out string nombre, out int edad))
            {
                return;
            }

            double precioEntrada = CalcularPrecioEntrada(edad);
            Persona persona = listaPersonas[personaSeleccionadaIndex];

            persona.Nombre = nombre;
            persona.Edad = edad;
            persona.PrecioFinal = precioEntrada;

            ListViewItem listItem = lstPersonas.Items[personaSeleccionadaIndex];
            listItem.SubItems[0].Text = persona.Nombre;
            listItem.SubItems[1].Text = persona.Edad.ToString();
            listItem.SubItems[2].Text = $"${persona.PrecioFinal:0.00}";

            ActualizarTotalRecaudado();
            LimpiarCampos();
        }

        private void AgregarDespuesDeSeleccionada()
        {
            if (lstPersonas.SelectedItems.Count > 0)
            {
                int personaSeleccionadaIndex = lstPersonas.SelectedIndices[0];

                if (ValidarCampos(out string nombre, out int edad))
                {
                    double precioEntrada = CalcularPrecioEntrada(edad);
                    Persona nuevaPersona = new Persona(nombre, edad, precioEntrada);

                    // Agregar la nueva persona en la lista después de la persona seleccionada
                    listaPersonas.Insert(personaSeleccionadaIndex + 1, nuevaPersona);

                    // Agregar la nueva persona en el ListView después de la persona seleccionada
                    ListViewItem item = new ListViewItem(nuevaPersona.Nombre);
                    item.SubItems.Add(nuevaPersona.Edad.ToString());
                    item.SubItems.Add($"${nuevaPersona.PrecioFinal:0.00}");

                    lstPersonas.Items.Insert(personaSeleccionadaIndex + 1, item);

                    ActualizarTotalRecaudado();
                    LimpiarCampos();
                }
            }
        }

        private bool ValidarCampos(out string nombre, out int edad) // Validar los campos de nombre y edad
        {
            nombre = txtNombre.Text;
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, ingrese un nombre válido.");
                edad = 0;
                return false;
            }

            if (!int.TryParse(txtEdad.Text, out edad) || edad < 5 || edad > 100)
            {
                MessageBox.Show("La edad debe ser un número entre 5 y 100.");
                return false;
            }

            return true;
        }

        private double CalcularPrecioEntrada(int edad) // Calcular el precio de entrada según la edad
        {
            if (edad >= 5 && edad <= 13) return 1000;
            if (edad <= 18) return 1500;
            if (edad <= 60) return 1900;
            return 1200;
        }

        private double CalcularTotalRecaudado() // Calcular el total recaudado
        {
            double total = 0;
            foreach (Persona persona in listaPersonas)
            {
                total += persona.PrecioFinal;
            }
            return total;
        }

        private void ActualizarListaPersonas() // Actualizar la lista de personas
        {
            lstPersonas.Items.Clear();
            foreach (Persona persona in listaPersonas)
            {
                ListViewItem item = new ListViewItem(persona.Nombre);
                item.SubItems.Add(persona.Edad.ToString());
                item.SubItems.Add($"${persona.PrecioFinal:0.00}"); // Mostrar el precio final
                lstPersonas.Items.Add(item);
            }

            ActualizarTotalRecaudado();
        }

        private void ActualizarTotalRecaudado() // Actualizar el total recaudado
        {
            double totalRecaudado = CalcularTotalRecaudado();
            lblTotalRecaudado.Text = "Total Recaudado: $" + totalRecaudado.ToString("0.00");
        }

        private void LimpiarCampos() // Limpiar los campos de nombre y edad
        {
            txtNombre.Clear();
            txtEdad.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e) // Evento click del botón Agregar
        {
            AgregarPersona();
        }

        private void btnEliminar_Click_Click(object sender, EventArgs e) // Evento click del botón Eliminar
        {
            EliminarPersona();
        }

        private void btnActualizar_Click_Click(object sender, EventArgs e) // Evento click del botón Actualizar
        {
            ActualizarPersona();
        }

        private void btnAgregarDespues_Click_Click(object sender, EventArgs e) // Evento click del botón Agregar Después
        {
            AgregarDespuesDeSeleccionada();
        }

        private void btnGenerarAleatorias_Click_Click(object sender, EventArgs e) // Evento click del botón Generar Aleatorias
        {
            GenerarPersonasAleatorias();
        }
        private void GenerarPersonasAleatorias() // Generar personas aleatorias
        {
            Random random = new Random();
            int cantidadPersonas = random.Next(51); // Número aleatorio entre 0 y 50

            for (int i = 0; i < cantidadPersonas; i++)
            {
                int edad = random.Next(5, 61); // Edad aleatoria entre 5 y 60
                string nombre = "Persona " + (i + 1); // Nombre genérico
                double precioEntrada = CalcularPrecioEntrada(edad);

                Persona nuevaPersona = new Persona(nombre, edad, precioEntrada);
                nuevaPersona.PrecioFinal = precioEntrada; // Asignar el precio final
                listaPersonas.Add(nuevaPersona);
            }

            ActualizarListaPersonas();
        }
    }
}
