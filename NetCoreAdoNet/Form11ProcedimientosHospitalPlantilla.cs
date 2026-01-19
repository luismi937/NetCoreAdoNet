using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#region PROCEDIMIENTOS ALMACENADOS
//create procedure SP_ALLHOSPITALES
//as
//	select * from HOSPITAL
//go
//create procedure SP_UPDATE_PLANTILLA_HOSPITAL
//(@nombre as NVARCHAR(50), @incremento int)
//as
//	declare @hospitalcod int 
//	select @hospitalcod  = HOSPITAL_COD from HOSPITAL
//	where NOMBRE=@nombre
//	update PLANTILLA set SALARIO = SALARIO + @incremento
//	where HOSPITAL_COD=@hospitalcod
//go
//create procedure SP_PLANTILLA_HOSPITAL
//(@nombre nvarchar(50))
//as 
//	select PLANTILLA.* from PLANTILLA
//	inner join HOSPITAL
//	on HOSPITAL.HOSPITAL.COD = PLANTILLA.HOSPITAL_COD
//	where HOSPITAL.NOMBRE=@nombre
//go
#endregion

namespace NetCoreAdoNet
{
    public partial class Form11ProcedimientosHospitalPlantilla : Form
    {

        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form11ProcedimientosHospitalPlantilla()
        {
            InitializeComponent();
            string connectionString = "Data Source=LOCALHOST\\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadHospitales();
        }
        private async Task LoadHospitales()
        {
            string sql = "SP_ALL_HOSPITALES";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["NOMBRE"].ToString();
                this.cmbHospitales.Items.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

        }

        private async void btnModificarSalarios_Click(object sender, EventArgs e)
        {
            //si tenemos parametros debemos incluirlos en el com, no en la consulta 
            string sql = "SP_UPDATE_PLANTILLA_HOSPITAL";
            string nombreHospital = this.cmbHospitales.SelectedItem.ToString();
            int incremento = int.Parse(this.textBox1.Text);
            this.com.Parameters.AddWithValue("@nombre", nombreHospital);
            MessageBox.Show("Hola klk");
            this.com.Parameters.AddWithValue("@incremento", incremento);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            int registros = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            await this.LoadPlantillaHOspital(nombreHospital);

            MessageBox.Show($"Se han modificado {registros} salarios");

        }
        private async Task LoadPlantillaHOspital(string nombreHospital)
        {
            string sql = "SP_PLANTILLA_HOSPITAL";
            this.com.Parameters.AddWithValue("@nombre", nombreHospital);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            this.lstPlantilla.Items.Clear();
            while (await this.reader.ReadAsync())
            {
                string empleado = this.reader["APELLIDO"].ToString();
                //el decimal es compatible con el money de sql server 
                //si quisiesemos hacerlo sin decimal seria asi: double salario = Convert.ToDouble(this.reader["SALARIO"]);
                //o tambien string salario = this.reader["SALARIO"].ToString();
                decimal salario = (decimal)this.reader["SALARIO"];
                this.lstPlantilla.Items.Add($"{empleado} - {salario}");
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

        }

        private void cmbHospitales_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
