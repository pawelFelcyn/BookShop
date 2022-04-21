using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder OnUserCreating(this ModelBuilder builder)
        {
            builder.Entity<User>(e =>
            {
                e.Property(u => u.Email)
                .IsRequired();

                e.Property(u => u.FirstName)
                .HasMaxLength(20)
                .IsRequired();

                e.Property(u => u.LastName)
                .HasMaxLength(20)
                .IsRequired();

                e.Property(u => u.RoleName)
                .IsRequired();

                e.Property(u => u.PasswordHash)
                .IsRequired();

                e.Property(u => u.Registered)
                .IsRequired();

                e.Property(u => u.AddressId)
                .IsRequired();
            });

            return builder;
        }

        public static ModelBuilder OnAddressCreating(this ModelBuilder builder)
        {
            builder.Entity<Address>(e =>
            {
                e.Property(a => a.Country)
                .HasMaxLength(30)
                .IsRequired();

                e.Property(a => a.City)
                .HasMaxLength(30)
                .IsRequired();

                e.Property(a => a.Street)
                .HasMaxLength(30)
                .IsRequired();

                e.Property(a => a.PostalCode)
                .HasMaxLength(6)
                .IsRequired();
            });

            return builder;
        }

        public static ModelBuilder OnBookCategoryCreating(this ModelBuilder builder)
        {
            builder.Entity<BookCategory>(e =>
            {
                e.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);
            });

            return builder;
        }

        public static ModelBuilder OnAuthorCreating(this ModelBuilder builder)
        {
            builder.Entity<BookAuthor>(e =>
            {
                e.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(30);

                e.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(30);
            });

            return builder;
        }

        public static ModelBuilder OnPublisherCreating(this ModelBuilder builder)
        {
            builder.Entity<Publisher>(e =>
            {
                e.Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(50);

                e.Property(p => p.ShortName)
                .HasMaxLength(10);
            });

            return builder;
        }

        public static ModelBuilder OnBookCreating(this ModelBuilder builder)
        {
            builder.Entity<Book>(e =>
            {
                e.Property(b => b.PublisherId)
                .IsRequired();

                e.Property(b => b.AuthorId)
                .IsRequired();

                e.Property(b => b.CategoryId)
                .IsRequired();

                e.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(70);

                e.Property(b => b.Description)
                .HasMaxLength(500);

                e.Property(b => b.Amount)
                .HasDefaultValue(0)
                .IsRequired();
            });

            return builder;
        }
    }
}
