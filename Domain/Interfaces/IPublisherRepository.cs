using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces
{
    internal interface IPublisherRepository
    {
        IQueryable<Publisher> GetAll();
        Publisher GetById(int id);
        Publisher Add(Publisher publisher);
        Publisher Update(Publisher publisher);
        void Remove(Publisher publisher);
    }
}
