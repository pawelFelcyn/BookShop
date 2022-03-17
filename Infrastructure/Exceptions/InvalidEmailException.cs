using Domain.Exceptions;

namespace Infrastructure.Exceptions
{
    public class InvalidEmailException : BadRequestException
    {
        public InvalidEmailException() : base("Invalid email")
        {
        }
    }
}
