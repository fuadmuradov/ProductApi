using FluentValidation;
using Product.Service.DTOs.ProductCategoryDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.FluentValidation
{
    public class CategoryValidation:AbstractValidator<ProductCategoryPostDto>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.ProductCategoryName)
                .NotNull().WithMessage("Name Cannot be Null")
                .MaximumLength(300).WithMessage("Name Characters must be lower then 300");
        }
    }
}
