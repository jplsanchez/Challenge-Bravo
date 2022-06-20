using System.Linq.Expressions;

namespace CB.Core.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression);

        Task<List<T>> GetAll();

        Task Add(T entity);

        Task Edit(T entity);

        Task Delete(Guid id);
    }
}
