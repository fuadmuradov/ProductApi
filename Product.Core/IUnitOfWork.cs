using Product.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Core
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }
    }
}
