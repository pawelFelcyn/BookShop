using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IBookCategoryRepository
    {
        IQueryable<BookCategory> GetAll();
        BookCategory GetById(int id);
        BookCategory Add(BookCategory category);
        BookCategory Update(BookCategory category);
        void Remove(BookCategory category);
    }
}
