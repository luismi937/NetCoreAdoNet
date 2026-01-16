using Microsoft.Data.SqlClient;
using NetCoreAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NetCoreAdoNet.Repositories
{
    public class RepositoryHospitales
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryHospitales()
        {
            string connectionString = "Data Source=LOCALHOST\\DEVELOPER;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            string sql = "select * from HOSPITAL";

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();

            List<Hospital> hospitales = new List<Hospital>();

            while(await this.reader.ReadAsync())
            {
                Hospital hospital = new Hospital();
                hospital.idHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = this.reader["NOMBRE"].ToString();
                hospital.Direccion = this.reader["DIRECCION"].ToString();
                hospital.Telefono = this.reader["TELEFONO"].ToString();
                hospital.NumeroCamas = int.Parse(this.reader["NUM_CAMA"].ToString());
                hospitales.Add(hospital);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();

            return hospitales;
        }

        public async Task<int> InsertarHospitalAsync(Hospital hospital)
        {
            string sql = "insert into HOSPITAL (HOSPITAL_COD, NOMBRE, DIRECCION, TELEFONO, NUM_CAMA) values (@idHospital, @nombre, @direccion, @telefono, @numCamas)";
            SqlParameter idHospital = new SqlParameter("@idHospital", hospital.idHospital);
            SqlParameter nombre = new SqlParameter("@nombre", hospital.Nombre);
            SqlParameter direccion = new SqlParameter("@direccion", hospital.Direccion);
            SqlParameter telefono = new SqlParameter("@telefono", hospital.Telefono);
            SqlParameter camas = new SqlParameter("@numCamas", hospital.NumeroCamas);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.com.Parameters.Add(idHospital);
            this.com.Parameters.Add(nombre);
            this.com.Parameters.Add(direccion);
            this.com.Parameters.Add(telefono);
            this.com.Parameters.Add(camas);

            await this.cn.OpenAsync();
            
            int registros = await this.com.ExecuteNonQueryAsync();
            
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            
            return registros;
        }

        public async Task<int> ModificarHospitalAsync(Hospital hospital)
        {
            string sql = "update HOSPITAL set NOMBRE = @nombre, DIRECCION = @direccion, TELEFONO = @telefono, NUM_CAMA = @numCamas where HOSPITAL_COD = @idHospital";
            SqlParameter idHospital = new SqlParameter("@idHospital", hospital.idHospital);
            SqlParameter nombre = new SqlParameter("@nombre", hospital.Nombre);
            SqlParameter direccion = new SqlParameter("@direccion", hospital.Direccion);
            SqlParameter telefono = new SqlParameter("@telefono", hospital.Telefono);
            SqlParameter camas = new SqlParameter("@numCamas", hospital.NumeroCamas);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.com.Parameters.Add(idHospital);
            this.com.Parameters.Add(nombre);
            this.com.Parameters.Add(direccion);
            this.com.Parameters.Add(telefono);
            this.com.Parameters.Add(camas);

            await this.cn.OpenAsync();

            int registros = await this.com.ExecuteNonQueryAsync();

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return registros;
        }

        public async Task<int> EliminarHospitalAsync(string idHospital)
        {
            string sql = "delete from HOSPITAL where HOSPITAL_COD = @idHospital";
            SqlParameter paramId = new SqlParameter("@idHospital", idHospital);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.com.Parameters.Add(paramId);

            await this.cn.OpenAsync();

            int registros = await this.com.ExecuteNonQueryAsync();

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return registros; 
        }
    }
}