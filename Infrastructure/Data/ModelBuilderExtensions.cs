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
    }
}
