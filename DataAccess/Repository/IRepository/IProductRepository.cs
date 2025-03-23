using Models;

namespace DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        public void SaveChanges();
        public void UpdateProduct(Product product);
    }
}
