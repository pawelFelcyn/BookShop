using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BookShopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<BookCategory> Categories { get; set; }
        public DbSet<BookAuthor> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookShopDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.OnUserCreating()
                        .OnAddressCreating()
                        .OnBookCategoryCreating()
                        .OnAuthorCreating()
                        .OnPublisherCreating()
                        .OnBookCreating();
        }
    }
}
