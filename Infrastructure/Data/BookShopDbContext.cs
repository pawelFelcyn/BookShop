using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
