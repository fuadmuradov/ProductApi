using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Core.Entities
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public IList<Product> Products { get; set; }
    }
}
