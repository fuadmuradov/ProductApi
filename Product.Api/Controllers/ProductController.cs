using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Service.DTOs.ProductDto;
using Product.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await productService.GetProductAsync(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductPostDto postDto)
        {
            await productService.CreateProductAsync(postDto);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await productService.DeleteProductAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductPostDto postDto)
        {
            var response = await productService.UpdateProductAsync(id, postDto);
            return StatusCode(200, response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await productService.GetAllProduct();
            return Ok(response);
        }
    }
}
