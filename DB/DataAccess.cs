using Dapper;
using Dapper.Mapper;
using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration config;

        public DataAccess(IConfiguration _Config) //Constructor 
        {
            config = _Config; //propiedad de nuestro constructor


        }

        public SqlConnection DbConnection => new SqlConnection // Metodo para guardar el string de conexion
            (
            new SqlConnectionStringBuilder(config.GetConnectionString("Conn")).ConnectionString
            );

        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, object Param = null, int? Timeout = null) // 1 relacion
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<dynamic>> QueryAsync(string sp, object Param = null, int? Timeout = null) // 1 relacion
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B>(string sp, object Param = null, int? Timeout = null) //2 relacion
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C>(string sp, object Param = null, int? Timeout = null) //3 relacionES
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D>(string sp, object Param = null, int? Timeout = null) //4 relaciones
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E>(string sp, object Param = null, int? Timeout = null) //5 relaciones
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D, E>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F>(string sp, object Param = null, int? Timeout = null) //6 relaciones
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D, E, F>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T, B, C, D, E, F, G>(string sp, object Param = null, int? Timeout = null) //7 relaciones
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();
                    var result = exec.QueryAsync<T, B, C, D, E, F, G>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure,
                        commandTimeout: Timeout);
                    return await result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Definir los metodos CRUD
        public async Task<T> QueryFirstAsync<T>(string sp, object Param = null, int? Timeout = null)
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryFirstOrDefaultAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure,
                            commandTimeout: Timeout);
                    return await result;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> ExecuteAsync(string sp, object Param = null, int? Timeout = null) // Metodo para las demas operaciones CRUD consultar, insertar etc
        {
            try
            {
                using (var exec = DbConnection)
                {
                    await exec.OpenAsync();

                    var result = await exec.ExecuteReaderAsync(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure,
                            commandTimeout: Timeout);
                    await result.ReadAsync();
                    return new() //Para que nos retorne los errores
                    { // Definimos las variables que necesitamos retornar
                        CodeError = result.GetInt32(0),
                        MsgError = result.GetString(1)
                    };


                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
