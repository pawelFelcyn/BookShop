using System;

namespace Domain.Entities
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public int Amount { get; set; }
        
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int PublisherId { get; set; }
        public virtual BookAuthor Author { get; set; }
        public virtual BookCategory Category { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
