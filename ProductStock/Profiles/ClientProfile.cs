using System;
using AutoMapper;
using ProductStock.Data.Dtos;
using ProductStock.Models;

namespace ProductStock.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientDto, Client>();
        }
    }
}