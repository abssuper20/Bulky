﻿using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAcess.Data;
using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository category { get; private set; }
        public IProductRepository product { get; private set; }
        public ICompanyRepository company { get; private set; }
        public IShoppingCartRepository shoppingCart { get; private set; }
        public IApplicationUserRepository applicationUser { get; private set; }
        public IOrderDetailRepository orderDetail { get; private set; }
        public IOrderHeaderRepository orderHeader { get; private set; }
        public IProductImageRepository productImage { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            category = new CategoryRepository(db);
            product = new ProductRepository(db);
            company = new CompanyRepository(db);
            shoppingCart = new ShoppingCartRepository(db);
            applicationUser = new ApplicationUserRepository(db);
            orderHeader = new OrderHeaderRepository(db);
            orderDetail = new OrderDetailRepository(db);
            productImage = new ProductImageRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
