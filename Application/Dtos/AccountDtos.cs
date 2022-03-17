using System;

namespace Application.Dtos
{
    public record RegisterDto(string FirstName, string LastName, DateTime? Birthdate, string Email,
    string PhoneNumber, string RoleName, string Country, string City, string Street,
    string PostalCode, string Password, string ConfirmPassword);

    public record LoginDto(string Email, string Password);
}