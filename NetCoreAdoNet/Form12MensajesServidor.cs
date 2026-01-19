using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCoreAdoNet
{
    public partial class Form12MensajesServidor : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form12MensajesServidor()
        {
            InitializeComponent();
            string connectionString = "Data Source=LOCALHOST\\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            //string connectionString = "Data Source=sqlpaco3430.database.windows.net;Initial Catalog=AZURETAJAMAR;Persist Security Info=True;User ID=adminsql;Password=Admin123;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.cn.InfoMessage += Cn_InfoMessage; ;
            this.com.Connection = this.cn;

             LoadDepartamentos();
        }

        private void Cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.lblServidor.Text = e.Message;
        }

        private async Task LoadDepartamentos()
        {
            this.lstDepartamentos.Items.Clear();
            string sql = "SP_ALL_DEPARTAMENTOS";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            try
            {
                using (var localReader = await this.com.ExecuteReaderAsync())
                {
                    while (await localReader.ReadAsync())
                    {
                        string nombre = localReader["DNOMBRE"].ToString();
                        string localidad = localReader["LOC"].ToString();
                        int numero = int.Parse(localReader["DEPT_NO"].ToString());
                        this.lstDepartamentos.Items.Add(numero + " - " + nombre + " - " + localidad);
                    }
                }
            }
            finally
            {
                await this.cn.CloseAsync();
            }
        }

        private async void btnNuevoDepartamento_Click(object sender, EventArgs e)
        {
            this.lblServidor.Text = "";

            int numero = int.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string localidad = this.txtLocalidad.Text;
            string sql = "SP_INSERT_DEPARTAMENTO";

            this.com.Parameters.AddWithValue("@numero", numero);
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.Parameters.AddWithValue("@localidad", localidad);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();

            //int registros = await this.com.ExecuteNonQueryAsync();
            int registros = this.com.ExecuteNonQuery();

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            this.LoadDepartamentos();

            MessageBox.Show("Departamentos insertados: " + registros);
        }
    }
}