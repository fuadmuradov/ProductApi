using Product.Core.IRepositories;
using Product.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Data.Repositories
{
    public class ProductRepository:Repository<Product.Core.Entities.Product>, IProductRepository
    {
        public ProductRepository(ProductContext context):base(context)
        {            
        }
    }
}
