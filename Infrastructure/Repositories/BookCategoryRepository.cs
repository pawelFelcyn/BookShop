using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly BookShopDbContext _dbContext;

        public BookCategoryRepository(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<BookCategory> GetAll()
        {
            return _dbContext.Categories;
        }

        public BookCategory GetById(int id)
        {
            return _dbContext
                   .Categories.FirstOrDefault(c => c.Id == id) ??
                   throw new BookCategoryNotFoundException();
        }

        public BookCategory Add(BookCategory category)
        {
            _dbContext.Add(category);
            _dbContext.SaveChanges();

            return category;
        }

        public BookCategory Update(BookCategory category)
        {
            _dbContext.Update(category);
            _dbContext.SaveChanges();

            return category;
        }

        public void Remove(BookCategory category)
        {
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }
    }
}
