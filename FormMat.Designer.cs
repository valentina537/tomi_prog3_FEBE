namespace SistemaAlumnos.FE
{
    partial class FormMat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Eliminar = new Button();
            Editar = new Button();
            Agregar = new Button();
            NombreMateria = new TextBox();
            dgvMaterias = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).BeginInit();
            SuspendLayout();
            // 
            // Eliminar
            // 
            Eliminar.Location = new Point(104, 133);
            Eliminar.Name = "Eliminar";
            Eliminar.Size = new Size(94, 29);
            Eliminar.TabIndex = 0;
            Eliminar.Text = "Eliminar";
            Eliminar.UseVisualStyleBackColor = true;
            Eliminar.Click += Eliminar_Click;
            // 
            // Editar
            // 
            Editar.Location = new Point(104, 98);
            Editar.Name = "Editar";
            Editar.Size = new Size(94, 29);
            Editar.TabIndex = 1;
            Editar.Text = "Editar";
            Editar.UseVisualStyleBackColor = true;
            Editar.Click += Editar_Click;
            // 
            // Agregar
            // 
            Agregar.Location = new Point(104, 65);
            Agregar.Name = "Agregar";
            Agregar.Size = new Size(94, 29);
            Agregar.TabIndex = 2;
            Agregar.Text = "Agregar";
            Agregar.UseVisualStyleBackColor = true;
            Agregar.Click += Agregar_Click;
            // 
            // NombreMateria
            // 
            NombreMateria.Location = new Point(261, 67);
            NombreMateria.Name = "NombreMateria";
            NombreMateria.Size = new Size(260, 27);
            NombreMateria.TabIndex = 3;
            // 
            // dgvMaterias
            // 
            dgvMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterias.Location = new Point(69, 221);
            dgvMaterias.Name = "dgvMaterias";
            dgvMaterias.RowHeadersWidth = 51;
            dgvMaterias.Size = new Size(664, 188);
            dgvMaterias.TabIndex = 4;
            dgvMaterias.CellContentClick += dgvMaterias_CellContentClick;
            // 
            // FormMat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 459);
            Controls.Add(dgvMaterias);
            Controls.Add(NombreMateria);
            Controls.Add(Agregar);
            Controls.Add(Editar);
            Controls.Add(Eliminar);
            Name = "FormMat";
            Text = "FormMat";
            Load += FormMat_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Eliminar;
        private Button Editar;
        private Button Agregar;
        private TextBox NombreMateria;
        private DataGridView dgvMaterias;
    }
}