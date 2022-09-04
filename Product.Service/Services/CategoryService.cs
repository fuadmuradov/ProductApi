using AutoMapper;
using Product.Core;
using Product.Core.Entities;
using Product.Service.DTOs.ProductCategoryDto;
using Product.Service.Exceptions;
using Product.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task CreateProductCategoryAsync(ProductCategoryPostDto postDto)
        {
            ProductCategory category = mapper.Map<ProductCategory>(postDto);
            await unitOfWork.ProductCategoryRepository.AddAsync(category);
            await unitOfWork.ProductCategoryRepository.SaveDbAsync();

        }

        public async Task DeleteProductCategoryAsync(int id)
        {
            ProductCategory category = await unitOfWork.ProductCategoryRepository.GetAsync(x => x.ProductCategoryId == id);
            if (category == null)
                throw new ItemNotFoundException($"Item Not Found by Id({id})");
            unitOfWork.ProductCategoryRepository.Remove(category);
            unitOfWork.ProductCategoryRepository.SaveDb();
        }

        public async Task<List<ProductCategoryGetDto>> GetAllProductCategory()
        {
            List<ProductCategory> categories = unitOfWork.ProductCategoryRepository.GetAll(x => x.ProductCategoryId > 0).ToList();
            if (categories.Count == 0)
                throw new ItemNotFoundException("Item Not Found");
            List<ProductCategoryGetDto> productCategories = mapper.Map<List<ProductCategory>, List<ProductCategoryGetDto>>(categories);
            return productCategories;
        }

        public async Task<ProductCategoryGetDto> GetProductCategoryAsync(int id)
        {
            ProductCategory category = await unitOfWork.ProductCategoryRepository.GetAsync(x => x.ProductCategoryId == id, "Products");
            if (category == null)
                throw new ItemNotFoundException($"Item Not Found by Id({id})");
            ProductCategoryGetDto productCategoryGet = mapper.Map<ProductCategoryGetDto>(category);
            return productCategoryGet;
        }

        public async Task<ProductCategoryGetDto> UpdateProductCategoryAsync(int id, ProductCategoryPostDto postDto)
        {
            ProductCategory category = await unitOfWork.ProductCategoryRepository.GetAsync(x => x.ProductCategoryId == id);
            if (category == null)
                throw new ItemNotFoundException($"Item Not Found by Id({id})");
            category.ProductCategoryName = postDto.ProductCategoryName;
            await unitOfWork.ProductCategoryRepository.SaveDbAsync();
            ProductCategoryGetDto productCategoryGet = mapper.Map<ProductCategoryGetDto>(category);
            return productCategoryGet;
        }
    }
}
