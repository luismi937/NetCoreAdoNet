namespace NetCoreAdoNet
{
    partial class Form04EliminarPlantilla
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
            label2 = new Label();
            btnEliminar = new Button();
            lstPlantillas = new ListBox();
            txtPlantilla = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(130, 11);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 9;
            label2.Text = "Plantillas";
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(24, 58);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 39);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar plantilla";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lstPlantillas
            // 
            lstPlantillas.FormattingEnabled = true;
            lstPlantillas.Location = new Point(130, 29);
            lstPlantillas.Name = "lstPlantillas";
            lstPlantillas.Size = new Size(218, 214);
            lstPlantillas.TabIndex = 7;
            // 
            // txtPlantilla
            // 
            txtPlantilla.Location = new Point(12, 29);
            txtPlantilla.Name = "txtPlantilla";
            txtPlantilla.Size = new Size(100, 23);
            txtPlantilla.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 5;
            label1.Text = "Id plantilla";
            // 
            // Form04EliminarPlantilla
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 307);
            Controls.Add(label2);
            Controls.Add(btnEliminar);
            Controls.Add(lstPlantillas);
            Controls.Add(txtPlantilla);
            Controls.Add(label1);
            Name = "Form04EliminarPlantilla";
            Text = "Form04EliminarPlantilla";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button btnEliminar;
        private ListBox lstPlantillas;
        private TextBox txtPlantilla;
        private Label label1;
    }
}