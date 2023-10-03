using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad2
{
    public partial class Form1 : Form
    {
        internal class FilaDatos
        {
            public string Columna1 { get; set; }
            public string Columna2 { get; set; }
            public string Columna3 { get; set; }
            public string Columna4 { get; set; }
            public string Columna5 { get; set; }
        }
        private List<FilaDatos> listaDatos = new List<FilaDatos>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (AgregarNuevaFila())
            {
                LimpiarTextBox();
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            DataGridViewRow associatedRow = checkBox.Tag as DataGridViewRow;

            bool checkBoxValue = checkBox.Checked;

            if (associatedRow != null)
            {
                int columnaDisponibilidadIndex = dataGridView1.Columns["Disponibilidad"].Index;
                associatedRow.Cells[columnaDisponibilidadIndex].Value = checkBoxValue ? "Disponible" : "No disponible";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EliminarFilaSeleccionada();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ActualizarFilaSeleccionada())
            {
                LimpiarTextBox();
            }
        }

        private void btnCotizar_Click(object sender, EventArgs e)
        {
            Cotizar();
        }

        private void LimpiarTextBox()
        {
            txtRemis.Text = "";
            txtModelo.Text = "";
            txtPatente.Text = "";
            txtSerie.Text = "";
            txtCombustible.Text = "";
            txtDistancia.Text = "";
            txtCategoria.Text = "";
        }

        private bool AgregarNuevaFila()
        {
            string nroRemis = txtRemis.Text;
            string modelo = txtModelo.Text;
            string patente = txtPatente.Text;
            string serie = txtSerie.Text;
            string combustible = txtCombustible.Text;

            if (CamposVacios(nroRemis, modelo, patente, serie, combustible))
            {
                MessageBox.Show("Debe completar todos los campos");
                return false;
            }

            foreach (FilaDatos fila in listaDatos)
            {
                if (fila.Columna1 == nroRemis)
                {
                    MessageBox.Show("El número de remis ya existe");
                    return false;
                }
                if (fila.Columna3 == patente)
                {
                    MessageBox.Show("La patente ya existe");
                    return false;
                }
            }

            FilaDatos nuevaFila = new FilaDatos
            {
                Columna1 = nroRemis,
                Columna2 = modelo,
                Columna3 = patente,
                Columna4 = serie,
                Columna5 = combustible
            };

            listaDatos.Add(nuevaFila);
            AgregarFilaDataGridView(nuevaFila);
            return true;
        }

        private void AgregarFilaDataGridView(FilaDatos fila)
        {
            dataGridView1.Rows.Add(fila.Columna1, fila.Columna2, fila.Columna3, fila.Columna4, fila.Columna5);

            DataGridViewRow addedRow = dataGridView1.Rows[dataGridView1.Rows.Count - 2];

            CheckBox newCheckBox = new CheckBox();
            newCheckBox.Text = "Disponible";
            newCheckBox.Checked = false;
            newCheckBox.Tag = addedRow;
            newCheckBox.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
            newCheckBox.Location = new Point(10, groupCheckBox.Controls.Count * 25);
            newCheckBox.Size = new Size(150, 20);
            groupCheckBox.Controls.Add(newCheckBox);
        }

        private void EliminarFilaSeleccionada()
        {
            if (dataGridView1.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("No se puede eliminar una fila vacía");
                return;
            }

            int rowIndex = dataGridView1.CurrentRow.Index;
            listaDatos.RemoveAt(rowIndex);
            dataGridView1.Rows.RemoveAt(rowIndex);
        }

        private bool ActualizarFilaSeleccionada()
        {
            string nroRemis = txtRemis.Text;
            string modelo = txtModelo.Text;
            string patente = txtPatente.Text;
            string serie = txtSerie.Text;
            string combustible = txtCombustible.Text;

            if (CamposVacios(nroRemis, modelo, patente, serie, combustible))
            {
                MessageBox.Show("Debe completar todos los campos");
                return false;
            }

            int rowIndex = dataGridView1.CurrentRow.Index;
            listaDatos[rowIndex].Columna1 = nroRemis;
            listaDatos[rowIndex].Columna2 = modelo;
            listaDatos[rowIndex].Columna3 = patente;
            listaDatos[rowIndex].Columna4 = serie;
            listaDatos[rowIndex].Columna5 = combustible;

            dataGridView1.CurrentRow.Cells[0].Value = nroRemis;
            dataGridView1.CurrentRow.Cells[1].Value = modelo;
            dataGridView1.CurrentRow.Cells[2].Value = patente;
            dataGridView1.CurrentRow.Cells[3].Value = serie;
            dataGridView1.CurrentRow.Cells[4].Value = combustible;

            return true;
        }

        private bool CamposVacios(params string[] campos)
        {
            foreach (string campo in campos)
            {
                if (string.IsNullOrWhiteSpace(campo))
                {
                    return true;
                }
            }
            return false;
        }

        private void Cotizar()
        {
            int distancia;
            if (!int.TryParse(txtDistancia.Text, out distancia))
            {
                MessageBox.Show("Ingrese una distancia válida");
                return;
            }
            string categoria = txtCategoria.Text;

            // Realizar la lógica de cotización aquí
            // ...
        }
    }

}
