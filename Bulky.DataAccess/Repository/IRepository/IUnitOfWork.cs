namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository category { get; }
        IProductRepository product { get; }
        void Save();
    }
}
