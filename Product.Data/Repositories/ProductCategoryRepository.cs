using Product.Core.Entities;
using Product.Core.IRepositories;
using Product.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Data.Repositories
{
    public class ProductCategoryRepository:Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ProductContext context):base(context)
        {

        }
    }
}
