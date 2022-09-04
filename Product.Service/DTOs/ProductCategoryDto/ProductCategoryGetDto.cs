using Product.Service.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.DTOs.ProductCategoryDto
{
    public class ProductCategoryGetDto
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
        public IList<ProductGetDto> Products { get; set; }
    }
}
