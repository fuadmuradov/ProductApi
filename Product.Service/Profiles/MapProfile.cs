using AutoMapper;
using Product.Core.Entities;
using Product.Service.DTOs.ProductCategoryDto;
using Product.Service.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Service.Profiles
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product.Core.Entities.Product, ProductGetDto>();
            CreateMap<ProductPostDto, Product.Core.Entities.Product>();
            CreateMap<ProductCategory, ProductCategoryGetDto>();
            CreateMap<ProductCategoryPostDto, ProductCategory>();
        }
    }
}
