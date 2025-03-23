using DataAccess.Repository.IRepository;
using Models;
using SimplifyWithGO.DataContext;

namespace DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private readonly AppDBContext _db;

        public ProductRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _db.Product.Update(product);
            _db.SaveChanges();
        }
    }
}
