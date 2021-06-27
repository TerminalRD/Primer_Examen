using DB;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IDeparmentsService
    {
        Task<IEnumerable<DeparmentsEntity>> Get();
        Task<DeparmentsEntity> GetById(DeparmentsEntity entity);
    }

    public class DeparmentsService : IDeparmentsService
    {
        private readonly IDataAccess sql; // Propiedad privada de la interfaz

        public DeparmentsService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<DeparmentsEntity>> Get()//SP Obtener
        {
            try
            {
                var result = sql.QueryAsync<DeparmentsEntity>(sp: "DeparmentsObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DeparmentsEntity> GetById(DeparmentsEntity entity)//SP 
        {
            try
            {
                var result = sql.QueryFirstAsync<DeparmentsEntity>("DeparmentsObtener", new
                { entity.Id_Departamento });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Create(DeparmentsEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("DeparmentsInsertar", new
                {
                    entity.Descripcion,
                    entity.Ubicacion,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Update(DeparmentsEntity entity) // Actualizar
        {
            try
            {
                var result = sql.ExecuteAsync("DeparmentsActualizar", new
                {
                    entity.Id_Departamento,
                    entity.Descripcion,
                    entity.Ubicacion,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Delete(DeparmentsEntity entity) // Eliminar
        {
            try
            {
                var result = sql.ExecuteAsync("DeparmentsEliminar", new
                {
                    entity.Id_Departamento
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
