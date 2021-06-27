using DB;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IJobsService
    {
        Task<DBEntity> Create(JobsEntity entity);
        Task<DBEntity> Delete(JobsEntity entity);
        Task<IEnumerable<JobsEntity>> Get();
        Task<JobsEntity> GetById(JobsEntity entity);
        Task<DBEntity> Update(JobsEntity entity);
    }

    public class JobsService : IJobsService
    {
        private readonly IDataAccess sql; // Propiedad privada de la interfaz

        public JobsService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<JobsEntity>> Get()//SP Obtener
        {
            try
            {
                var result = sql.QueryAsync<JobsEntity>(sp: "JobsObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<JobsEntity> GetById(JobsEntity entity)//SP 
        {
            try
            {
                var result = sql.QueryFirstAsync<JobsEntity>("JobsObtener", new
                { entity.Id_Puesto });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Create(JobsEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("JobsInsertar", new
                {
                    entity.Nombre,
                    entity.Salario,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Update(JobsEntity entity) // Actualizar
        {
            try
            {
                var result = sql.ExecuteAsync("JobsActualizar", new
                {
                    entity.Id_Puesto,
                    entity.Nombre,
                    entity.Salario,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Delete(JobsEntity entity) // Eliminar
        {
            try
            {
                var result = sql.ExecuteAsync("JobsEliminar", new
                {
                    entity.Id_Puesto
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
