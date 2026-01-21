using Microsoft.Data.SqlClient;
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

#region STRORED PROCEDURES
//create procedure SP_EMPLEADOS_DEPARTAMENTOS_OUT
//(@nombre NVARCHAR(50)
//, @suma int OUT
//, @media int OUT
//, @personas int OUT)
//as
//	declare @iddept int
//	select @iddept = DEPT_NO from DEPT
//	where DNOMBRE=@nombre
//	--la consulta del procedimiento
//	select * from EMP where DEPT_NO=@iddept
//	--rellenamos las variables de salida
//	select @suma = SUM(SALARIO), @media = AVG(SALARIO), @personas = COUNT(EMP_NO) from EMP
//	where DEPT_NO = @iddept
//go
    #endregion




namespace NetCoreAdoNet
{
    public partial class Form13ParametrosSalida : Form
    {
        RepositoryParametersOut repo;
       
        public Form13ParametrosSalida()
        {
            InitializeComponent();
            this.repo = new RepositoryParametersOut();
            LoadDepartamentos();

        }
        private async void LoadDepartamentos()
        {
            List<string> departamentos = await this.repo.GetDepartamentosAsync();
            this.cmbDepartamentos.Items.Clear();
            foreach (var dept in departamentos)
            {
                this.cmbDepartamentos.Items.Add(dept);
            } 
            //this.cmbDepartamentos.Items.Clear();
            //string sql = "SP_ALL_DEPARTAMENTOS";
            //this.com.CommandType = CommandType.Text;
            //this.com.CommandText = sql;
            //await this.cn.OpenAsync();
            //this.reader = await this.com.ExecuteReaderAsync();
            //while (await this.reader.ReadAsync())
            //{
            //    string nombre = this.reader["DNOMBRE"].ToString();
            //    this.cmbDepartamentos.Items.Add(nombre);
            //}
            //await this.reader.CloseAsync();
            //await this.cn.CloseAsync();

        }

        private async void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            //al tener el repositorio, el codigo de la conexion y demas se encapsula ahi
            string nombreDept = this.cmbDepartamentos.SelectedItem.ToString();
            EmpleadosParametersOut model = await this.repo.GetEmpleadosModelAsync(nombreDept);
            this.repo.GetEmpleadosModelAsync(nombreDept);
            this.lstEmpleados.Items.Clear();
            foreach (var empleado in model.Apellidos)
            {
                this.lstEmpleados.Items.Add(empleado);
            }
            this.txtPersonas.Text = model.Personas.ToString();
            this.textBox1.Text = model.SumaSalarial.ToString();
            this.textBox2.Text = model.MediaSalarial.ToString();



            //string sql = "SP_EMPLEADOS_DEPARTAMENTOS_OUT";
            ////tenemos un parametro de entrada, por defecto todos son de entrada
            ////podemos seguir usando AddWithValue con dicho parametro
            //string nombreDept = this.cmbDepartamentos.SelectedItem.ToString();
            //this.com.Parameters.AddWithValue("@nombre", nombreDept);
            ////los parametros de salida debemos crearlos de forma explicita
            //SqlParameter paramSuma = new SqlParameter();
            //paramSuma.ParameterName = "@suma";
            //paramSuma.Value = 0;
            ////que value de suma enviamos al procedimiento
            //paramSuma.Direction = ParameterDirection.Output;
            //this.com.Parameters.Add(paramSuma);
            //SqlParameter paramMedia = new SqlParameter();
            //paramMedia.ParameterName = "@media";
            //paramMedia.Value = 0;
            //paramMedia.Direction = ParameterDirection.Output;
            //this.com.Parameters.Add(paramMedia);
            //SqlParameter paramPersonas = new SqlParameter();
            //paramPersonas.ParameterName = "@personas";
            //paramPersonas.Value = 0;
            //paramPersonas.Direction = ParameterDirection.Output;
            //this.com.Parameters.Add(paramPersonas);
            //this.com.CommandType = CommandType.StoredProcedure;
            //this.com.CommandText = sql;
            //await this.cn.OpenAsync();
            //this.reader = await this.com.ExecuteReaderAsync();
            //this.lstEmpleados.Items.Clear();
            //while (await this.reader.ReadAsync())
            //{
            //    string empleado = this.reader["APELLIDO"].ToString();
            //    this.lstEmpleados.Items.Add(empleado);
            //}
            ////dibujamos los parametros
            //await this.reader.CloseAsync();

            //this.txtPersonas.Text = paramPersonas.Value.ToString();
            //this.textBox1.Text = paramSuma.Value.ToString();
            //this.textBox2.Text = paramMedia.Value.ToString();
            ////liberamos los recursos de la conexion y demas 

            //await this.cn.CloseAsync();
            //this.com.Parameters.Clear();




        }
    }
}
