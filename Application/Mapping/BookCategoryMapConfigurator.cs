using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class BookCategoryMapConfigurator : IMapCongigurator
    {
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<BookCategory, BookCategoryDto>();
            profile.CreateMap<CreateBookCategoryDto, BookCategory>();
        }
    }
}
