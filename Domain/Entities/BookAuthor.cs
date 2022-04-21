using System.Collections.Generic;

namespace Domain.Entities
{
    public class BookAuthor : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
