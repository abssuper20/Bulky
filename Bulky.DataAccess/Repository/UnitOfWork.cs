using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAcess.Data;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository category { get; private set; }
        public IProductRepository product { get; private set; }
        public ICompanyRepository company { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            category = new CategoryRepository(db);
            product = new ProductRepository(db);
            company = new CompanyRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
