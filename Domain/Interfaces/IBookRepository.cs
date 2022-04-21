using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Book> GetAll();
        Book GetById(int id);
        Book Add(Book book);
        Book Update(Book book);
        void Remove(int id);
    }
}
