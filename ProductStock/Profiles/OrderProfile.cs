using System;
using AutoMapper;
using ProductStock.Data.Dtos;
using ProductStock.Models;

namespace ProductStock.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>();
        }
    }
}
