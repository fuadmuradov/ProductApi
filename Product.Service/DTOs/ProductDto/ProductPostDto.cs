using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.DTOs.ProductDto
{
    public class ProductPostDto
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public bool State { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
