using Microsoft.Data.SqlClient;
using NetCoreAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryDepartamentos
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryDepartamentos()
        {
            string connectionString = "Data Source=LOCALHOST\\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = cn;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            string sql = "select * from DEPT";

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            
            await this.cn.OpenAsync();
            
            this.reader = await this.com.ExecuteReaderAsync();

            List<Departamento> departamentos = new List<Departamento>();

            while (await this.reader.ReadAsync())
            {
                Departamento departamento = new Departamento();
                departamento.IdDepartamento = int.Parse(this.reader["DEPT_NO"].ToString());
                departamento.Nombre = this.reader["DNOMBRE"].ToString();
                departamento.Localidad = this.reader["LOC"].ToString();

                departamentos.Add(departamento);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

            return departamentos;
        }

        public async Task<int> AddDepartamentoAsync(Departamento departamento)
        {
            string sql = "insert into DEPT (DEPT_NO, DNOMBRE, LOC) VALUES (@idDepartamento, @nombre, @localidad)";
            SqlParameter idDepartamento = new SqlParameter("@idDepartamento", departamento.IdDepartamento);
            SqlParameter nombre = new SqlParameter("@nombre", departamento.Nombre);
            SqlParameter localidad = new SqlParameter("@localidad", departamento.Localidad);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            this.com.Parameters.Add(idDepartamento);
            this.com.Parameters.Add(nombre);
            this.com.Parameters.Add(localidad);

            await this.cn.OpenAsync();

            int registros = await this.com.ExecuteNonQueryAsync();

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return registros;
        }

        public async Task<int> UpdateDepartamentoAsync(Departamento departamento) 
        {
            string sql = "update DEPT set DNOMBRE = @nombre, LOC = @localidad where DEPT_NO = @idDepartamento";
            SqlParameter idDepartamento = new SqlParameter("@idDepartamento", departamento.IdDepartamento);
            SqlParameter nombre = new SqlParameter("@nombre", departamento.Nombre);
            SqlParameter localidad = new SqlParameter("@localidad", departamento.Localidad);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.com.Parameters.Add(idDepartamento);
            this.com.Parameters.Add(nombre);
            this.com.Parameters.Add(localidad);

            await this.cn.OpenAsync();

            int registros = await this.com.ExecuteNonQueryAsync();

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return registros;
        }

        public async Task<int> DeleteDepartamentoAsync(int idDepartamento)
        {
            string sql = "delete from DEPT where DEPT_NO = @idDepartamento";
            SqlParameter id = new SqlParameter("@idDepartamento", idDepartamento);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.com.Parameters.Add(id);

            await this.cn.OpenAsync();
            
            int registros = await this.com.ExecuteNonQueryAsync();
            
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return registros;
        }
    }
}