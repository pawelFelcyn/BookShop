using System.Collections.Generic;

namespace Domain.Entities
{
    public class BookCategory : Entity
    {
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
