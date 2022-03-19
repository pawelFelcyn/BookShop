namespace Domain.Interfaces
{
    public interface IEmailValidationHelper
    {
        bool IsEmailTaken(string email);
    }
}
