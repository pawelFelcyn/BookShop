using Application.Dtos;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IBookCategoryService
    {
        IEnumerable<BookCategoryDto> GetAll();
        BookCategoryDto GetById(int id);
        BookCategoryDto Create(CreateBookCategoryDto dto);
        BookCategoryDto Update(UpdateBookCategoryDto dto, int id);
        void Delete(int id);
    }
}
