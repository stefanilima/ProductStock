using System;
using AutoMapper;
using ProductStock.Data.Dtos;
using ProductStock.Models;

namespace ProductStock.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}
