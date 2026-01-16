using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetCoreAdoNet
{
    public partial class Form04EliminarPlantilla : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public Form04EliminarPlantilla()
        {
            InitializeComponent();
            string connectionString = "Data Source=LOCALHOST\\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.loadPlantillas();
        }

        private void loadPlantillas()
        {
            string sql = "select * from PLANTILLA";

            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            this.cn.Open();

            this.reader = this.com.ExecuteReader();

            while (this.reader.Read())
            {
                string codHospital = this.reader["HOSPITAL_COD"].ToString();
                string codSala = this.reader["SALA_COD"].ToString();


            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
