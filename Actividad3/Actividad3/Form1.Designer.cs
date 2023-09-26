namespace Actividad3
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnAgregarDespues = new System.Windows.Forms.Button();
            this.lstPersonas = new System.Windows.Forms.ListView();
            this.clmnPersona = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnEdad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnPrecio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGenerarAleatorias = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.lblTotalRecaudado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(37, 96);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 0;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(118, 96);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(199, 96);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click_Click);
            // 
            // btnAgregarDespues
            // 
            this.btnAgregarDespues.Location = new System.Drawing.Point(280, 96);
            this.btnAgregarDespues.Name = "btnAgregarDespues";
            this.btnAgregarDespues.Size = new System.Drawing.Size(95, 23);
            this.btnAgregarDespues.TabIndex = 4;
            this.btnAgregarDespues.Text = "Agregar despues";
            this.btnAgregarDespues.UseVisualStyleBackColor = true;
            this.btnAgregarDespues.Click += new System.EventHandler(this.btnAgregarDespues_Click_Click);
            // 
            // lstPersonas
            // 
            this.lstPersonas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnPersona,
            this.clmnEdad,
            this.clmnPrecio});
            this.lstPersonas.HideSelection = false;
            this.lstPersonas.Location = new System.Drawing.Point(37, 157);
            this.lstPersonas.Name = "lstPersonas";
            this.lstPersonas.Size = new System.Drawing.Size(217, 97);
            this.lstPersonas.TabIndex = 5;
            this.lstPersonas.UseCompatibleStateImageBehavior = false;
            this.lstPersonas.View = System.Windows.Forms.View.Details;
            // 
            // clmnPersona
            // 
            this.clmnPersona.Text = "Persona";
            this.clmnPersona.Width = 93;
            // 
            // clmnEdad
            // 
            this.clmnEdad.Text = "Edad";
            // 
            // clmnPrecio
            // 
            this.clmnPrecio.Text = "Precio";
            // 
            // btnGenerarAleatorias
            // 
            this.btnGenerarAleatorias.Location = new System.Drawing.Point(381, 96);
            this.btnGenerarAleatorias.Name = "btnGenerarAleatorias";
            this.btnGenerarAleatorias.Size = new System.Drawing.Size(105, 23);
            this.btnGenerarAleatorias.TabIndex = 6;
            this.btnGenerarAleatorias.Text = "Generar aleatoria";
            this.btnGenerarAleatorias.UseVisualStyleBackColor = true;
            this.btnGenerarAleatorias.Click += new System.EventHandler(this.btnGenerarAleatorias_Click_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(93, 29);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 7;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(93, 55);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(100, 20);
            this.txtEdad.TabIndex = 8;
            // 
            // lblTotalRecaudado
            // 
            this.lblTotalRecaudado.AutoSize = true;
            this.lblTotalRecaudado.Location = new System.Drawing.Point(277, 241);
            this.lblTotalRecaudado.Name = "lblTotalRecaudado";
            this.lblTotalRecaudado.Size = new System.Drawing.Size(93, 13);
            this.lblTotalRecaudado.TabIndex = 10;
            this.lblTotalRecaudado.Text = "Total Recaudado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Edad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Nombre";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(497, 280);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalRecaudado);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnGenerarAleatorias);
            this.Controls.Add(this.lstPersonas);
            this.Controls.Add(this.btnAgregarDespues);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAgregar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnAgregarDespues;
        private System.Windows.Forms.ListView lstPersonas;
        private System.Windows.Forms.Button btnGenerarAleatorias;
        private System.Windows.Forms.ColumnHeader clmnPersona;
        private System.Windows.Forms.ColumnHeader clmnEdad;
        private System.Windows.Forms.ColumnHeader clmnPrecio;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label lblTotalRecaudado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

