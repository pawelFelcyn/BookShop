using Domain.Interfaces;
using Infrastructure.Data;
using System.Linq;

namespace Infrastructure.Helpers
{
    public class EmailValidationHelper : IEmailValidationHelper
    {
        private readonly BookShopDbContext _dbContext;

        public EmailValidationHelper(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsEmailTaken(string email)
        {
            return _dbContext.Users.Any(u => u.Email == email);
        }
    }
}
