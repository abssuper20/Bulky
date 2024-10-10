namespace Bulky.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository category { get; }
		IProductRepository product { get; }
		ICompanyRepository company { get; }
		IShoppingCartRepository shoppingCart { get; }
		IApplicationUserRepository applicationUser { get; }
		IOrderHeaderRepository orderHeader { get; }
		IOrderDetailRepository orderDetail { get; }
		void Save();
	}
}
