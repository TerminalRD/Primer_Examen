using DB;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface ITitlesService
    {
        Task<DBEntity> Create(TitlesEntity entity);
        Task<DBEntity> Delete(TitlesEntity entity);
        Task<IEnumerable<TitlesEntity>> Get();
        Task<TitlesEntity> GetById(TitlesEntity entity);
        Task<DBEntity> Update(TitlesEntity entity);
    }

    public class TitlesService : ITitlesService
    {
        private readonly IDataAccess sql; // Propiedad privada de la interfaz

        public TitlesService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<TitlesEntity>> Get()//SP Obtener
        {
            try
            {
                var result = sql.QueryAsync<TitlesEntity>(sp: "TitlesObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TitlesEntity> GetById(TitlesEntity entity)//SP 
        {
            try
            {
                var result = sql.QueryFirstAsync<TitlesEntity>("TitlesObtener", new
                { entity.Id_Titulo });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Create(TitlesEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("TitlesInsertar", new
                {
                    entity.Descripcion,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Update(TitlesEntity entity) // Actualizar
        {
            try
            {
                var result = sql.ExecuteAsync("TitlesActualizar", new
                {
                    entity.Id_Titulo,
                    entity.Descripcion,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DBEntity> Delete(TitlesEntity entity) // Eliminar
        {
            try
            {
                var result = sql.ExecuteAsync("TitlesEliminar", new
                {
                    entity.Id_Titulo
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
