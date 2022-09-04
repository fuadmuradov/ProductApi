using Product.Service.DTOs.ProductDto;
using Product.Service.IServices;
using System;
using Product.Core.Entities;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Product.Core;
using AutoMapper;
using Product.Service.Exceptions;
using System.Linq;

namespace Product.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task CreateProductAsync(ProductPostDto postDto)
        {
            Product.Core.Entities.Product product = mapper.Map<Product.Core.Entities.Product>(postDto);
            await unitOfWork.ProductRepository.AddAsync(product);
            await unitOfWork.ProductRepository.SaveDbAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            Product.Core.Entities.Product product = await unitOfWork.ProductRepository.GetAsync(x => x.ProductId == id && x.IsDeleted == false, "ProductCategory");
            if (product == null)
                throw new ItemNotFoundException($"Item Not Found by Id({id})");
            product.IsDeleted = true;
            unitOfWork.ProductRepository.SaveDb();
        }

        public async Task<List<ProductGetDto>> GetAllProduct()
        {
            List<Product.Core.Entities.Product> products = unitOfWork.ProductRepository.GetAll(x => x.IsDeleted == false, "ProductCategory").ToList();
            if (products.Count == 0)
                throw new ItemNotFoundException($"Item Not Found");
            List<ProductGetDto> productGets = mapper.Map<List<Product.Core.Entities.Product>, List<ProductGetDto>>(products);
            return productGets;
        }

        public async Task<ProductGetDto> GetProductAsync(int id)
        {
            Product.Core.Entities.Product product = await unitOfWork.ProductRepository.GetAsync(x => x.ProductId == id && x.IsDeleted == false, "ProductCategory");
            if (product == null)
                throw new ItemNotFoundException($"Item Not Found by Id({id})");
            ProductGetDto productGet = mapper.Map<ProductGetDto>(product);
            return productGet;
        }

        public async Task<ProductGetDto> UpdateProductAsync(int id, ProductPostDto postDto)
        {
            Product.Core.Entities.Product product = await unitOfWork.ProductRepository.GetAsync(x => x.ProductId == id && x.IsDeleted == false, "ProductCategory");
            if (product == null)
                throw new ItemNotFoundException($"Item Not Found by Id({id})");
            ProductCategory category = await unitOfWork.ProductCategoryRepository.GetAsync(x => x.ProductCategoryId == postDto.ProductCategoryId);
            if (category == null)
                throw new ItemNotFoundException($"Category Not Found by Id({postDto.ProductCategoryId})");
            product.ProductName = postDto.ProductName;
            product.ProductCategoryId = postDto.ProductCategoryId;
            product.State = postDto.State;
            product.Price = postDto.Price;
            await unitOfWork.ProductRepository.SaveDbAsync();
            ProductGetDto productGet = mapper.Map<ProductGetDto>(product);
            return productGet;
        }
    }
}
