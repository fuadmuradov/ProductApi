using Product.Service.DTOs.ProductCategoryDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.IServices
{
    public interface ICategoryService
    {
        Task CreateProductCategoryAsync(ProductCategoryPostDto postDto);
        Task<ProductCategoryGetDto> UpdateProductCategoryAsync(int id, ProductCategoryPostDto postDto);
        Task<ProductCategoryGetDto> GetProductCategoryAsync(int id);
        Task<List<ProductCategoryGetDto>> GetAllProductCategory();
        Task DeleteProductCategoryAsync(int id);
    }
}
