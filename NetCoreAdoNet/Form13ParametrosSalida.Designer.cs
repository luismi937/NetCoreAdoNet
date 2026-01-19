namespace NetCoreAdoNet
{
    partial class Form13ParametrosSalida
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
            lblDepartamentos = new Label();
            cmbDepartamentos = new ComboBox();
            lblEmpleados = new Label();
            lstEmpleados = new ListBox();
            btnMostrarDatos = new Button();
            lblSumaSalarial = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            lblMediaSalarial = new Label();
            txtPersonas = new TextBox();
            lblPersonas = new Label();
            SuspendLayout();
            // 
            // lblDepartamentos
            // 
            lblDepartamentos.AutoSize = true;
            lblDepartamentos.Location = new Point(41, 22);
            lblDepartamentos.Name = "lblDepartamentos";
            lblDepartamentos.Size = new Size(88, 15);
            lblDepartamentos.TabIndex = 0;
            lblDepartamentos.Text = "Departamentos";
            // 
            // cmbDepartamentos
            // 
            cmbDepartamentos.FormattingEnabled = true;
            cmbDepartamentos.Location = new Point(41, 40);
            cmbDepartamentos.Name = "cmbDepartamentos";
            cmbDepartamentos.Size = new Size(157, 23);
            cmbDepartamentos.TabIndex = 1;
            // 
            // lblEmpleados
            // 
            lblEmpleados.AutoSize = true;
            lblEmpleados.Location = new Point(259, 23);
            lblEmpleados.Name = "lblEmpleados";
            lblEmpleados.Size = new Size(65, 15);
            lblEmpleados.TabIndex = 2;
            lblEmpleados.Text = "Empleados";
            // 
            // lstEmpleados
            // 
            lstEmpleados.FormattingEnabled = true;
            lstEmpleados.Location = new Point(234, 41);
            lstEmpleados.Name = "lstEmpleados";
            lstEmpleados.Size = new Size(179, 199);
            lstEmpleados.TabIndex = 3;
            // 
            // btnMostrarDatos
            // 
            btnMostrarDatos.Location = new Point(41, 69);
            btnMostrarDatos.Name = "btnMostrarDatos";
            btnMostrarDatos.Size = new Size(75, 23);
            btnMostrarDatos.TabIndex = 4;
            btnMostrarDatos.Text = "Mostrar Datos";
            btnMostrarDatos.UseVisualStyleBackColor = true;
            btnMostrarDatos.Click += btnMostrarDatos_Click;
            // 
            // lblSumaSalarial
            // 
            lblSumaSalarial.AutoSize = true;
            lblSumaSalarial.Location = new Point(41, 111);
            lblSumaSalarial.Name = "lblSumaSalarial";
            lblSumaSalarial.Size = new Size(77, 15);
            lblSumaSalarial.TabIndex = 5;
            lblSumaSalarial.Text = "Suma Salarial";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(41, 129);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(41, 184);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 8;
            // 
            // lblMediaSalarial
            // 
            lblMediaSalarial.AutoSize = true;
            lblMediaSalarial.Location = new Point(41, 166);
            lblMediaSalarial.Name = "lblMediaSalarial";
            lblMediaSalarial.Size = new Size(77, 15);
            lblMediaSalarial.TabIndex = 7;
            lblMediaSalarial.Text = "MediaSalarial";
            // 
            // txtPersonas
            // 
            txtPersonas.Location = new Point(41, 228);
            txtPersonas.Name = "txtPersonas";
            txtPersonas.Size = new Size(100, 23);
            txtPersonas.TabIndex = 10;
            // 
            // lblPersonas
            // 
            lblPersonas.AutoSize = true;
            lblPersonas.Location = new Point(41, 210);
            lblPersonas.Name = "lblPersonas";
            lblPersonas.Size = new Size(54, 15);
            lblPersonas.TabIndex = 9;
            lblPersonas.Text = "Personas";
            // 
            // Form13ParametrosSalida
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 318);
            Controls.Add(txtPersonas);
            Controls.Add(lblPersonas);
            Controls.Add(textBox2);
            Controls.Add(lblMediaSalarial);
            Controls.Add(textBox1);
            Controls.Add(lblSumaSalarial);
            Controls.Add(btnMostrarDatos);
            Controls.Add(lstEmpleados);
            Controls.Add(lblEmpleados);
            Controls.Add(cmbDepartamentos);
            Controls.Add(lblDepartamentos);
            Name = "Form13ParametrosSalida";
            Text = "Form13ParametrosSalida";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDepartamentos;
        private ComboBox cmbDepartamentos;
        private Label lblEmpleados;
        private ListBox lstEmpleados;
        private Button btnMostrarDatos;
        private Label lblSumaSalarial;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label lblMediaSalarial;
        private TextBox txtPersonas;
        private Label lblPersonas;
    }
}