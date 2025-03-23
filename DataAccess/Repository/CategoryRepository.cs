using DataAccess.Repository.IRepository;
using SimplifyWithGO.DataContext;
using SimplifyWithGO.Models;

namespace DataAccess.Repository
{

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDBContext _db;
        public CategoryRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _db.Category.Update(category);
        }
    }
}
