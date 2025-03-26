using System.Linq.Expressions;

namespace DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T? Get(Expression<Func<T, bool>> filter, string? includeTable = null);
        IEnumerable<T> GetAll(string? includeTable = null);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
