using Microsoft.Data.SqlClient;
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
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form13ParametrosSalida()
        {
            InitializeComponent();
            string connectionString = "Data Source=LOCALHOST\\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            LoadDepartamentos();

        }
        private async void LoadDepartamentos()
        {
            this.cmbDepartamentos.Items.Clear();
            string sql = "SP_ALL_DEPARTAMENTOS";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                this.cmbDepartamentos.Items.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

        }

        private async void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            string sql = "SP_EMPLEADOS_DEPARTAMENTOS_OUT";
            //tenemos un parametro de entrada, por defecto todos son de entrada
            //podemos seguir usando AddWithValue con dicho parametro
            string nombreDept = this.cmbDepartamentos.SelectedItem.ToString();
            this.com.Parameters.AddWithValue("@nombre", nombreDept);
            //los parametros de salida debemos crearlos de forma explicita
            SqlParameter paramSuma = new SqlParameter();
            paramSuma.ParameterName = "@suma";
            paramSuma.Value = 0;
            //que value de suma enviamos al procedimiento
            paramSuma.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(paramSuma);
            SqlParameter paramMedia = new SqlParameter();
            paramMedia.ParameterName = "@media";
            paramMedia.Value = 0;
            paramMedia.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(paramMedia);
            SqlParameter paramPersonas = new SqlParameter();
            paramPersonas.ParameterName = "@personas";
            paramPersonas.Value = 0;
            paramPersonas.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(paramPersonas);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            this.lstEmpleados.Items.Clear();
            while (await this.reader.ReadAsync())
            {
                string empleado = this.reader["APELLIDO"].ToString();
                this.lstEmpleados.Items.Add(empleado);
            }
            //dibujamos los parametros
            await this.reader.CloseAsync();

            this.txtPersonas.Text = paramPersonas.Value.ToString();
            this.textBox1.Text = paramSuma.Value.ToString();
            this.textBox2.Text = paramMedia.Value.ToString();
            //liberamos los recursos de la conexion y demas 
            
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();




        }
    }
}
