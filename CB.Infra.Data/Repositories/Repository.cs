using CB.Core.Domain.Entities;
using CB.Core.Domain.Interfaces;
using CB.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CB.Infra.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly MainDbContext Db;
        private readonly DbSet<T> DbSet;

        public Repository(MainDbContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression)
        {
            return await DbSet.AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Add(T entity)
        {
            if (entity.Id == Guid.Empty)
            {
                entity.Id = Guid.NewGuid();
            }
            DbSet.Add(entity);
            await SaveChanges();
        }

        public async Task Edit(T entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Delete(Guid id)
        {
            DbSet.Remove(new T { Id = id });
            await SaveChanges();

        }

        private async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
