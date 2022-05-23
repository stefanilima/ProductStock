using AutoMapper;
using ProductStock.Data.Dtos;
using ProductStock.Models;

namespace ProductStock.Profiles
{
    public class PaymentTypeProfile : Profile
    {
        public PaymentTypeProfile()
        {
            CreateMap<PaymentTypeDto, PaymentType>();
        }
    }
}
