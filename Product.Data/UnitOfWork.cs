using Product.Core;
using Product.Core.IRepositories;
using Product.Data.Contexts;
using Product.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        IProductRepository productRepository;
        IProductCategoryRepository productCategoryRepository;
        private readonly ProductContext context;

        public UnitOfWork(ProductContext context)
        {
            this.context = context;
        }

        public IProductRepository ProductRepository => productRepository ?? new ProductRepository(context);

        public IProductCategoryRepository ProductCategoryRepository => productCategoryRepository ?? new ProductCategoryRepository(context);

       
    }
}
