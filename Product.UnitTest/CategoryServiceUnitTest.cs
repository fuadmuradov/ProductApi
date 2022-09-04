using NUnit.Framework;
using Product.Data.Contexts;
using Product.Service.Exceptions;
using Product.Service.IServices;
using Product.Service.Services;

namespace Product.UnitTest
{
    public class CategoryServiceUnitTest
    {
        private readonly ICategoryService categoryService;
        public CategoryServiceUnitTest(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [Test]
        public void Category_IdIsNotExist_ThrowItemNotFoundException()
        {
            var result = categoryService.GetProductCategoryAsync(100);
            if (result == null) Assert.Pass();
            else Assert.Fail();
        }
    }
}