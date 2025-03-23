using SimplifyWithGO.Models;
namespace DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Save();
        void UpdateCategory(Category category);
    }
}
