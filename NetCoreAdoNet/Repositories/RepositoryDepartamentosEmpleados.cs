using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryDepartamentosEmpleados
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryDepartamentosEmpleados()
        {
            string connectionString = "Data Source=LOCALHOST\\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<string>> LoadDepartamentos()
        {
            string sql = "select * from DEPARTAMENTOS";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();

            List<string> departamentos = new List<string>();

            while (await this.reader.ReadAsync())
            {
                string departamento = this.reader["DNOMBRE"].ToString();
                departamentos.Add(departamento);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

            return departamentos;
        }

        public async Task<int> GetDepartamentoIdByNombre(string departamento)
        {
            string sql = "select * from DEPARTAMENTOS where DNOMBRE=@departamento";
            SqlParameter nombre = new SqlParameter("@departamento", departamento);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.com.Parameters.Add(nombre);

            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();

            int id = -1;

            while (this.reader.Read())
            {
                id = int.Parse(this.reader["DEPT_NO"].ToString());
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return id;

        }

        public async Task<List<string>> GetEmpladosByDepartamento(int idDepartamento)
        {
            string sql = "select * from EMP where DEPT_NO=@idDepartamento";
            SqlParameter id = new SqlParameter("@idDepartamento", idDepartamento);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.com.Parameters.Add(id);

            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();

            List<string> empleados = new List<string>();

            while (await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                empleados.Add(apellido);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return empleados;
        }

        public async Task<int> DeleteEmpleado(string apellidoEmp)
        {
            string sql = "delete from EMP where APELLIDO=@apellido";
            SqlParameter apellido = new SqlParameter("@apellido", apellidoEmp);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.com.Parameters.Add(apellido);

            await this.cn.OpenAsync();

            int registros = await this.com.ExecuteNonQueryAsync();

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return registros;
        }
    }
}
