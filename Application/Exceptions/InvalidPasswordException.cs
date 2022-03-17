using Domain.Exceptions;

namespace Application.Exceptions
{
    public class InvalidPasswordException : BadRequestException
    {
        public InvalidPasswordException() : base("Invalid password")
        {
        }
    }
}
