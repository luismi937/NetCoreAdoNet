namespace NetCoreAdoNet
{
    partial class Form12MensajesServidor
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
            lblId = new Label();
            lblNombre = new Label();
            txtId = new TextBox();
            txtNombre = new TextBox();
            txtLocalidad = new TextBox();
            lblLocalidad = new Label();
            btnNuevoDepartamento = new Button();
            lblServidor = new Label();
            lblDepartamentos = new Label();
            lstDepartamentos = new ListBox();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(12, 9);
            lblId.Name = "lblId";
            lblId.Size = new Size(17, 15);
            lblId.TabIndex = 0;
            lblId.Text = "Id";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 63);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre";
            // 
            // txtId
            // 
            txtId.Location = new Point(12, 27);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 2;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 81);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 3;
            // 
            // txtLocalidad
            // 
            txtLocalidad.Location = new Point(12, 141);
            txtLocalidad.Name = "txtLocalidad";
            txtLocalidad.Size = new Size(100, 23);
            txtLocalidad.TabIndex = 4;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(12, 123);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(58, 15);
            lblLocalidad.TabIndex = 5;
            lblLocalidad.Text = "Localidad";
            // 
            // btnNuevoDepartamento
            // 
            btnNuevoDepartamento.Location = new Point(12, 184);
            btnNuevoDepartamento.Name = "btnNuevoDepartamento";
            btnNuevoDepartamento.Size = new Size(100, 44);
            btnNuevoDepartamento.TabIndex = 6;
            btnNuevoDepartamento.Text = "Nuevo Departamento";
            btnNuevoDepartamento.UseVisualStyleBackColor = true;
            btnNuevoDepartamento.Click += btnNuevoDepartamento_Click;
            // 
            // lblServidor
            // 
            lblServidor.AutoSize = true;
            lblServidor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServidor.ForeColor = Color.Blue;
            lblServidor.Location = new Point(12, 251);
            lblServidor.Name = "lblServidor";
            lblServidor.Size = new Size(68, 15);
            lblServidor.TabIndex = 7;
            lblServidor.Text = "lblServidor";
            // 
            // lblDepartamentos
            // 
            lblDepartamentos.AutoSize = true;
            lblDepartamentos.Location = new Point(178, 27);
            lblDepartamentos.Name = "lblDepartamentos";
            lblDepartamentos.Size = new Size(88, 15);
            lblDepartamentos.TabIndex = 8;
            lblDepartamentos.Text = "Departamentos";
            // 
            // lstDepartamentos
            // 
            lstDepartamentos.FormattingEnabled = true;
            lstDepartamentos.Location = new Point(178, 45);
            lstDepartamentos.Name = "lstDepartamentos";
            lstDepartamentos.Size = new Size(180, 169);
            lstDepartamentos.TabIndex = 9;
            // 
            // Form12MensajesServidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 289);
            Controls.Add(lstDepartamentos);
            Controls.Add(lblDepartamentos);
            Controls.Add(lblServidor);
            Controls.Add(btnNuevoDepartamento);
            Controls.Add(lblLocalidad);
            Controls.Add(txtLocalidad);
            Controls.Add(txtNombre);
            Controls.Add(txtId);
            Controls.Add(lblNombre);
            Controls.Add(lblId);
            Name = "Form12MensajesServidor";
            Text = "Form12MensajesServidor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private Label lblNombre;
        private TextBox txtId;
        private TextBox txtNombre;
        private TextBox txtLocalidad;
        private Label lblLocalidad;
        private Button btnNuevoDepartamento;
        private Label lblServidor;
        private Label lblDepartamentos;
        private ListBox lstDepartamentos;
    }
}