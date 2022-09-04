using Product.Service.DTOs.ProductCategoryDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.DTOs.ProductDto
{
    public class ProductGetDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool State { get; set; }
        public int ProductCategoryId { get; set; }
        public ProductCategoryGetDto ProductCategory { get; set; }
    }
}
