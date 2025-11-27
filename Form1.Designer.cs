namespace SistemaAlumnos.FE
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtLegajo = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            btnAgregar = new Button();
            dgvAlumnos = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnMaterias = new Button();
            Inscripcion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(118, 16);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(268, 27);
            txtNombre.TabIndex = 0;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(118, 55);
            txtApellido.Margin = new Padding(3, 4, 3, 4);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(268, 27);
            txtApellido.TabIndex = 1;
            // 
            // txtLegajo
            // 
            txtLegajo.Location = new Point(118, 93);
            txtLegajo.Margin = new Padding(3, 4, 3, 4);
            txtLegajo.Name = "txtLegajo";
            txtLegajo.Size = new Size(268, 27);
            txtLegajo.TabIndex = 2;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(118, 132);
            dtpFechaNacimiento.Margin = new Padding(3, 4, 3, 4);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(228, 27);
            dtpFechaNacimiento.TabIndex = 3;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(466, 20);
            btnAgregar.Margin = new Padding(3, 4, 3, 4);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(142, 31);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar Alumno";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvAlumnos
            // 
            dgvAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlumnos.Location = new Point(118, 209);
            dgvAlumnos.Margin = new Padding(3, 4, 3, 4);
            dgvAlumnos.Name = "dgvAlumnos";
            dgvAlumnos.RowHeadersWidth = 51;
            dgvAlumnos.Size = new Size(577, 166);
            dgvAlumnos.TabIndex = 3;
            dgvAlumnos.CellClick += dgvAlumnos_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 20);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 4;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 59);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 4;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 97);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 4;
            label3.Text = "Legajo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 140);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 4;
            label4.Text = "Fecha Nac.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 209);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 4;
            label5.Text = "Listado";
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(466, 87);
            btnActualizar.Margin = new Padding(3, 4, 3, 4);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(198, 31);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar Seleccionado";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(470, 156);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(179, 31);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar Seleccionado";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnMaterias
            // 
            btnMaterias.Location = new Point(24, 418);
            btnMaterias.Name = "btnMaterias";
            btnMaterias.Size = new Size(174, 29);
            btnMaterias.TabIndex = 7;
            btnMaterias.Text = "Ir a materias";
            btnMaterias.UseVisualStyleBackColor = true;
            btnMaterias.Click += btnMaterias_Click;
            // 
            // Inscripcion
            // 
            Inscripcion.Location = new Point(661, 418);
            Inscripcion.Name = "Inscripcion";
            Inscripcion.Size = new Size(94, 29);
            Inscripcion.TabIndex = 8;
            Inscripcion.Text = "Inscripcion";
            Inscripcion.UseVisualStyleBackColor = true;
            Inscripcion.Click += Inscripcion_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 459);
            Controls.Add(Inscripcion);
            Controls.Add(btnMaterias);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvAlumnos);
            Controls.Add(btnAgregar);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtLegajo);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Nuevo Alumno";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAlumnos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtLegajo;
        private DateTimePicker dtpFechaNacimiento;
        private Button btnAgregar;
        private DataGridView dgvAlumnos;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnMaterias;
        private Button Inscripcion;
    }
}
