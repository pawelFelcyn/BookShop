using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BookShopDbContext _dbContext;

        public AccountRepository(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public User GetByEmail(string email)
        {
            return _dbContext.Users
                   .FirstOrDefault(u => u.Email == email)
                   ?? throw new InvalidEmailException();
        }
    }
}
