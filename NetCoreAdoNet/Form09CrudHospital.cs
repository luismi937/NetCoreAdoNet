using NetCoreAdoNet.Models;
using NetCoreAdoNet.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCoreAdoNet
{
    public partial class Form09CrudHospital : Form
    {
        public RepositoryHospitales repo;

        public Form09CrudHospital()
        {
            InitializeComponent();
            this.repo = new RepositoryHospitales();
            this.LoadHospitales();
        }

        public async void LoadHospitales()
        {
            List<Hospital> hospitales = await this.repo.GetHospitalesAsync();
           
            this.lstHospitales.Items.Clear();

            foreach (Hospital hospital in hospitales)
            {
                this.lstHospitales.Items.Add(hospital.idHospital + " - " + hospital.Nombre);
            }
        }

        private async void btnInsertar_Click(object sender, EventArgs e)
        {
            Hospital hospital = new Hospital();

            hospital.idHospital = int.Parse(this.txtId.Text);
            hospital.Nombre = this.txtNombre.Text;
            hospital.Direccion = this.txtDireccion.Text;
            hospital.Telefono = this.txtTelefono.Text;
            hospital.NumeroCamas = int.Parse(this.txtNCamas.Text);

            int registros = await this.repo.InsertarHospitalAsync(hospital);

            MessageBox.Show("Registros insertados: " + registros);

            this.LoadHospitales();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            Hospital hospital = new Hospital();

            hospital.idHospital = int.Parse(this.txtId.Text);
            hospital.Nombre = this.txtNombre.Text;
            hospital.Direccion = this.txtDireccion.Text;
            hospital.Telefono = this.txtTelefono.Text;
            hospital.NumeroCamas = int.Parse(this.txtNCamas.Text);

            int registros = await this.repo.ModificarHospitalAsync(hospital);

            MessageBox.Show("Registros modificados: " + registros);

            this.LoadHospitales();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            string hospitalString = this.lstHospitales.SelectedItem.ToString();

            string idHospital = hospitalString.Split(" - ")[0].Trim();

            int registros = await this.repo.EliminarHospitalAsync(idHospital);

            MessageBox.Show("Registros eliminados: " + registros);

            this.LoadHospitales();
        }
    }
}
