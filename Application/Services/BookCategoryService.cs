using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Application.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IBookCategoryRepository _repository;
        private readonly IMapper _mapper;

        public BookCategoryService(IBookCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<BookCategoryDto> GetAll()
        {
            var allCategories = _repository.GetAll();

            return _mapper.Map<IEnumerable<BookCategoryDto>>(allCategories);
        }

        public BookCategoryDto GetById(int id)
        {
            var category = _repository.GetById(id);

            return _mapper.Map<BookCategoryDto>(category);
        }

        public BookCategoryDto Create(CreateBookCategoryDto dto)
        {
            var category = _mapper.Map<BookCategory>(dto);
            category = _repository.Add(category);

            return _mapper.Map<BookCategoryDto>(category);
        }

        public BookCategoryDto Update(UpdateBookCategoryDto dto, int id)
        {
            var category = _repository.GetById(id);

            category.Name = dto.Name;
            category = _repository.Update(category);

            return _mapper.Map<BookCategoryDto>(category);
        }

        public void Delete(int id)
        {
            var category = _repository.GetById(id);

            _repository.Remove(category);
        }
    }
}
