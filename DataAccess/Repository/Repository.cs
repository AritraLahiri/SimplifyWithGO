using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using SimplifyWithGO.DataContext;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDBContext _db;
        private DbSet<T> _dbSet;

        public Repository(AppDBContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }


        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T? Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            return query.FirstOrDefault(filter);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
