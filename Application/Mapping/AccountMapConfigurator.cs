using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Mapping
{
    public class AccountMapConfigurator : IMapCongigurator
    {
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<RegisterDto, User>()
                .ForMember(u => u.Registered, c => c.MapFrom(r => DateTime.UtcNow))
                .ForMember(u => u.Address, c => c.MapFrom(r => new Address()
                {
                    Country = r.Country,
                    City = r.City,
                    Street = r.Street,
                    PostalCode = r.PostalCode
                }));
        }
    }
}
