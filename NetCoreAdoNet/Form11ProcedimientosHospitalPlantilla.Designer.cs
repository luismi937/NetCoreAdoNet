namespace NetCoreAdoNet
{
    partial class Form11ProcedimientosHospitalPlantilla
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
            lblHospitales = new Label();
            cmbHospitales = new ComboBox();
            lblIncremento = new Label();
            textBox1 = new TextBox();
            btnModificarSalarios = new Button();
            lblPlantilla = new Label();
            lstPlantilla = new ListBox();
            SuspendLayout();
            // 
            // lblHospitales
            // 
            lblHospitales.AutoSize = true;
            lblHospitales.Location = new Point(28, 23);
            lblHospitales.Name = "lblHospitales";
            lblHospitales.Size = new Size(62, 15);
            lblHospitales.TabIndex = 0;
            lblHospitales.Text = "Hospitales";
            // 
            // cmbHospitales
            // 
            cmbHospitales.FormattingEnabled = true;
            cmbHospitales.Location = new Point(28, 55);
            cmbHospitales.Name = "cmbHospitales";
            cmbHospitales.Size = new Size(121, 23);
            cmbHospitales.TabIndex = 1;
            // 
            // lblIncremento
            // 
            lblIncremento.AutoSize = true;
            lblIncremento.Location = new Point(196, 23);
            lblIncremento.Name = "lblIncremento";
            lblIncremento.Size = new Size(68, 15);
            lblIncremento.TabIndex = 3;
            lblIncremento.Text = "Incremento";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(196, 55);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 4;
            // 
            // btnModificarSalarios
            // 
            btnModificarSalarios.Location = new Point(96, 125);
            btnModificarSalarios.Name = "btnModificarSalarios";
            btnModificarSalarios.Size = new Size(146, 23);
            btnModificarSalarios.TabIndex = 5;
            btnModificarSalarios.Text = "Modificar Salarios";
            btnModificarSalarios.UseVisualStyleBackColor = true;
            btnModificarSalarios.Click += btnModificarSalarios_Click;
            // 
            // lblPlantilla
            // 
            lblPlantilla.AutoSize = true;
            lblPlantilla.Location = new Point(28, 178);
            lblPlantilla.Name = "lblPlantilla";
            lblPlantilla.Size = new Size(49, 15);
            lblPlantilla.TabIndex = 6;
            lblPlantilla.Text = "Plantilla";
            // 
            // lstPlantilla
            // 
            lstPlantilla.FormattingEnabled = true;
            lstPlantilla.Location = new Point(28, 215);
            lstPlantilla.Name = "lstPlantilla";
            lstPlantilla.Size = new Size(177, 94);
            lstPlantilla.TabIndex = 7;
            // 
            // Form11ProcedimientosHospitalPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(385, 346);
            Controls.Add(lstPlantilla);
            Controls.Add(lblPlantilla);
            Controls.Add(btnModificarSalarios);
            Controls.Add(textBox1);
            Controls.Add(lblIncremento);
            Controls.Add(cmbHospitales);
            Controls.Add(lblHospitales);
            Name = "Form11ProcedimientosHospitalPlantilla";
            Text = "Form11ProcedimientosHospitalPlantilla";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHospitales;
        private ComboBox cmbHospitales;
        private Label lblIncremento;
        private TextBox textBox1;
        private Button btnModificarSalarios;
        private Label lblPlantilla;
        private ListBox lstPlantilla;
    }
}