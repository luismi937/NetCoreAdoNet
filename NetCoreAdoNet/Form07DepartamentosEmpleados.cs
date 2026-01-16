using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCoreAdoNet.Repositories
{
    public partial class Form07DepartamentosEmpleados : Form
    {
        RepositoryDepartamentosEmpleados repo;

        public Form07DepartamentosEmpleados()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentosEmpleados();
            this.loadDepartamentos();
        }

        private async void loadDepartamentos()
        {
            List<string> departametos = await this.repo.LoadDepartamentos();

            foreach (string departamento in departametos)
            {
                lstDepartamentos.Items.Add(departamento);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            string empleadoSeleccionado = this.lstEmpleados.SelectedItem.ToString();

            int registros = await this.repo.DeleteEmpleado(empleadoSeleccionado);

            MessageBox.Show("Registros eliminados: " + registros);

            string departamentoSeleccionado = this.lstDepartamentos.SelectedItem.ToString();
            int idDepartamento = await this.repo.GetDepartamentoIdByNombre(departamentoSeleccionado);

            this.VisualizarEmpleados(idDepartamento);
        }

        private async void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string departamentoSeleccionado = this.lstDepartamentos.SelectedItem.ToString();
            int idDepartamento = await this.repo.GetDepartamentoIdByNombre(departamentoSeleccionado);
            
            this.VisualizarEmpleados(idDepartamento);
        }

        private async void VisualizarEmpleados(int idDepartamento)
        {
            List<string> empleados = await this.repo.GetEmpladosByDepartamento(idDepartamento);

            this.lstEmpleados.Items.Clear();

            foreach (string empleado in empleados)
            {
                this.lstEmpleados.Items.Add(empleado);
            }
        }
    }
}
