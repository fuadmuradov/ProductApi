using FluentValidation;
using Product.Service.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.FluentValidation
{
    public class ProductValidation:AbstractValidator<ProductPostDto>
    {
        public ProductValidation()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(300).WithMessage("Characters must be lower then 300");
            RuleFor(x => x.Price)
                .NotNull().WithMessage("Price propert cannot be null"); ;
            RuleFor(x => x.ProductCategoryId)
                .NotNull().WithMessage("CategoryId propert cannot be null"); ;
            RuleFor(x => x.State)
                .NotNull().WithMessage("State propert cannot be null");
        }
    }
}
