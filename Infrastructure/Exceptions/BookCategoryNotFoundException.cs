using Domain.Exceptions;

namespace Infrastructure.Exceptions
{
    internal class BookCategoryNotFoundException : NotFoundException
    {
        public BookCategoryNotFoundException() : base("Category with given id was not found in database")
        {

        }
    }
}
