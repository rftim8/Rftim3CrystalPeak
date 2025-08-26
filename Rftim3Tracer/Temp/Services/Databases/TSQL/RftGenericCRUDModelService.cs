using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Rftim3Atlas.Models;
using Rftim3Tracer.Services.Databases.MSSQL;

namespace Rftim3Tracer.Temp.Services.Databases.TSQL
{
    public class RftGenericCRUDModelService<T>(RftDbContextFactoryMSSQL rftDbContextFactory) : IRftGenericCRUDModelService<T> where T : RftGenericModel
    {
        private readonly RftDbContextFactoryMSSQL rftDbContextFactory = rftDbContextFactory;

        public async Task<T> Create(T entity)
        {
            using RftDbContextMSSQL rftDbContextMSSQL = rftDbContextFactory.CreateDbContext();
            EntityEntry<T> entityEntry = await rftDbContextMSSQL.Set<T>().AddAsync(entity);
            await rftDbContextMSSQL.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<T?> ReadOne(uint id)
        {
            using RftDbContextMSSQL rftDbContextMSSQL = rftDbContextFactory.CreateDbContext();
            T? entity = await rftDbContextMSSQL.Set<T>().FirstOrDefaultAsync(o => o.Id == id);

            return entity;
        }

        public async Task<List<T>> ReadAll()
        {
            using RftDbContextMSSQL rftDbContextMSSQL = rftDbContextFactory.CreateDbContext();
            List<T> entities = await rftDbContextMSSQL.Set<T>().ToListAsync();

            return entities;
        }

        public async Task<T> Update(uint id, T entity)
        {
            using RftDbContextMSSQL rftDbContextMSSQL = rftDbContextFactory.CreateDbContext();
            entity.Id = id;
            rftDbContextMSSQL.Set<T>().Update(entity);
            await rftDbContextMSSQL.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(uint id)
        {
            using RftDbContextMSSQL rftDbContextMSSQL = rftDbContextFactory.CreateDbContext();
            T? entity = await rftDbContextMSSQL.Set<T>().FirstOrDefaultAsync(o => o.Id == id);
            if (entity is not null)
            {
                rftDbContextMSSQL.Set<T>().Remove(entity);
                await rftDbContextMSSQL.SaveChangesAsync();
            }

            return true;
        }
    }
}
