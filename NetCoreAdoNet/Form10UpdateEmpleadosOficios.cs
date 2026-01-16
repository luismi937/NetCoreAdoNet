using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCoreAdoNet.Repositories
{
    public partial class Form10UpdateEmpleadosOficios : Form
    {
        private RepositoryUpdateEmpleado repo;

        public Form10UpdateEmpleadosOficios()
        {
            InitializeComponent();
            this.repo = new RepositoryUpdateEmpleado();
            this.GetOficios();
        }

        private async void GetOficios()
        {
            List<string> oficios = await this.repo.GetOficiosAsync();

            this.lstOficios.Items.Clear();

            foreach (string oficio in oficios)
            {
                this.lstOficios.Items.Add(oficio);
            }
        }

        private async void btnIncremento_Click(object sender, EventArgs e)
        {
            int incremento = int.Parse(this.txtIncrememto.Text);
            string oficio = this.lstOficios.SelectedItem.ToString();

            int afectados = this.repo.UpdateSalarioEmpleadosAsync(oficio, incremento).Result;

            MessageBox.Show($"Empleados afectados: {afectados}");

            List<string> empleados = await this.repo.GetEmpleadosByOficioAsync(oficio);
            
            lstEmpleados.Items.Clear();

            foreach (string empleado in empleados)
            {
                this.lstEmpleados.Items.Add(empleado);
            }
        }

        private async void lstOficios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.lstOficios.SelectedIndex;
            if (index != -1)
            {
                string oficio = this.lstOficios.SelectedItem.ToString();

                List<string> empleados = await this.repo.GetEmpleadosByOficioAsync(oficio);

                this.lstEmpleados.Items.Clear();

                foreach (string empleado in empleados)
                {
                    this.lstEmpleados.Items.Add(empleado);
                }
            }
        }
    }
}
