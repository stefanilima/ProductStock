using AutoMapper;
using ProductStock.Data.Dtos;
using ProductStock.Models;

namespace ProductStock.Profiles
{
    public class OrderProductProfile : Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProductDto, OrderProduct>();
        }
    }
}
