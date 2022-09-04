using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Service.DTOs.ProductCategoryDto;
using Product.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await categoryService.GetProductCategoryAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCategoryPostDto postDto)
        {
            await categoryService.CreateProductCategoryAsync(postDto);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await categoryService.DeleteProductCategoryAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductCategoryPostDto postDto)
        {
            var response = await categoryService.UpdateProductCategoryAsync(id, postDto);
            return StatusCode(200, response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await categoryService.GetAllProductCategory();
            return Ok(response);
        }
    }
}
