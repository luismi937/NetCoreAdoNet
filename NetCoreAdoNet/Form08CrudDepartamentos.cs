using NetCoreAdoNet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCoreAdoNet.Repositories
{
    public partial class Form08CrudDepartamentos : Form
    {
        RepositoryDepartamentos repo;

        public Form08CrudDepartamentos()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentos();
            this.LoadDepartamentos();
        }

        private async void LoadDepartamentos()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();

            this.lstDepartamentos.Items.Clear();

            foreach (Departamento departamento in departamentos) 
            {
                this.lstDepartamentos.Items.Add(departamento.IdDepartamento + " - " + departamento.Nombre + " - " + departamento.Localidad);
            }
        }

        private async void btnInsertar_Click(object sender, EventArgs e)
        {
            Departamento departamento = new Departamento();

            departamento.IdDepartamento = int.Parse(this.txtId.Text);
            departamento.Nombre = this.txtNombre.Text;
            departamento.Localidad = this.txtLocalidad.Text;

            int registros = await this.repo.AddDepartamentoAsync(departamento);

            MessageBox.Show("Registros insertados: " + registros);

            txtId.Clear();
            txtNombre.Clear();
            txtLocalidad.Clear();

            this.LoadDepartamentos();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            Departamento departamento = new Departamento();

            departamento.IdDepartamento = int.Parse(this.txtId.Text);
            departamento.Nombre = this.txtNombre.Text;
            departamento.Localidad = this.txtLocalidad.Text;

            int registros = await this.repo.UpdateDepartamentoAsync(departamento);

            MessageBox.Show("Registros modificados: " + registros);
            
            txtId.Clear();
            txtNombre.Clear();
            txtLocalidad.Clear();

            this.LoadDepartamentos();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            string departamentoString = this.lstDepartamentos.SelectedItem.ToString();
            string [] partes = departamentoString.Split(" - ");
            int idDepartamento = int.Parse(partes[0].Trim());

            int registros = await this.repo.DeleteDepartamentoAsync(idDepartamento);

            MessageBox.Show("Registros eliminados: " + registros);

            this.LoadDepartamentos();
        }
    }
}