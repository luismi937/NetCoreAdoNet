using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NetCoreAdoNet.Helpers;
using NetCoreAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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


namespace NetCoreAdoNet.Repositories
{
    public class RepositoryParametersOut
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public RepositoryParametersOut()
        {
            IConfigurationRoot configuration = HelperConfiguration.GetConfiguration();
            string connectionString = configuration.GetConnectionString("SqlTajamarLocal");
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }
        public async Task<List<string>> GetDepartamentosAsync()
        {

            string sql = "SP_ALL_DEPARTAMENTOS";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> departamentos = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["DNOMBRE"].ToString();
                departamentos.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return departamentos;
        }
        public async Task<EmpleadosParametersOut> GetEmpleadosModelAsync(string nombre)
        {
            EmpleadosParametersOut model = new EmpleadosParametersOut();
            string sql = "SP_EMPLEADOS_DEPARTAMENTOS_OUT";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            SqlParameter pnombre = new SqlParameter("@nombre", nombre);
            SqlParameter psuma = new SqlParameter("@suma", SqlDbType.Int);
            psuma.Direction = ParameterDirection.Output;
            SqlParameter pmedia = new SqlParameter("@media", SqlDbType.Int);
            pmedia.Direction = ParameterDirection.Output;
            SqlParameter ppersonas = new SqlParameter("@personas", SqlDbType.Int);
            ppersonas.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pnombre);
            this.com.Parameters.Add(psuma);
            this.com.Parameters.Add(pmedia);
            this.com.Parameters.Add(ppersonas);
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> apellidos = new List<string>();
            while (await this.reader.ReadAsync())
            {
                string apellido = this.reader["APELLIDO"].ToString();
                apellidos.Add(apellido);
            }
            await this.reader.CloseAsync();
            model.Apellidos = apellidos;
            model.SumaSalarial = (int)psuma.Value;
            model.MediaSalarial = (int)pmedia.Value;
            model.Personas = (int)ppersonas.Value;
            this.com.Parameters.Clear();
            await this.cn.CloseAsync();
            return model;

        }
    }
}
