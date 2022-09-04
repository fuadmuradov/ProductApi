using Product.Service.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.IServices
{
    public interface IProductService
    {
        Task CreateProductAsync(ProductPostDto postDto);
        Task<ProductGetDto> UpdateProductAsync(int id, ProductPostDto postDto);
        Task<ProductGetDto> GetProductAsync(int id);
        Task<List<ProductGetDto>> GetAllProduct();
        Task DeleteProductAsync(int id);
    }
}
