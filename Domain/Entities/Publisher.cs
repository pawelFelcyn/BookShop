using System.Collections.Generic;

namespace Domain.Entities
{
    public class Publisher : Entity
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}
