using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IAuthorRepository
    {
        IQueryable<BookAuthor> GetAll();
        BookAuthor GetById(int id);
        BookAuthor Add(BookAuthor author);
        BookAuthor Update(BookAuthor author);
        void Remove(BookAuthor author);
    }
}
