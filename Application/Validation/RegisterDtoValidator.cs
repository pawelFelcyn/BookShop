using Application.Dtos;
using Application.Extensions;
using Domain.Interfaces;
using FluentValidation;
using System;
using System.Linq;

namespace Application.Validation
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        private readonly IEmailValidationHelper _emailValidationHelper;
        private const char SEPARATOR = ',';
        private readonly string[] _allowedReleNames =
            new[] { "Admin", "Manager", "User" };

        public RegisterDtoValidator(IEmailValidationHelper emailValidationHelper)
        {
            _emailValidationHelper = emailValidationHelper;

            SetRulesForFirstName();
            SetRulesForLastName();
            SetRulesForBirthdate();
            SetRulesForEmail();
            SetRulesForPhoneNumber();
            SetRulesForRoleName();
            SetRulesForCountry();
            SetRulesForCity();
            SetRulesForStreet();
            SetRulesForPostalCode();
            SetRulesForPassword();
            SetRulesForConfirmPassword();
        }

        private void SetRulesForFirstName()
        {
            RuleFor(r => r.FirstName)
                .MaximumLength(20)
                .WithMessage("Maximum length of firstname is 20 characters");

            RuleFor(r => r.FirstName)
                .NotEmpty()
                .WithMessage("Firstname must not be empty");
        }

        private void SetRulesForLastName()
        {
            RuleFor(r => r.LastName)
                .MaximumLength(20)
                .WithMessage("Maximum length of lastname is 20 characters");

            RuleFor(r => r.LastName)
                .NotEmpty()
                .WithMessage("Lastname must not be empty");
        }

        private void SetRulesForBirthdate()
        {
            RuleFor(r => r.Birthdate)
                .Must(b => b is null || b < DateTime.UtcNow)
                .WithMessage("Birthdate must be earlier than now");
        }

        private void SetRulesForEmail()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Email must not be empty");

            RuleFor(r => r.Email)
                .EmailAddress()
                .WithMessage("This is not a valid email address");

            RuleFor(r => r.Email)
                .Must(e => !_emailValidationHelper.IsEmailTaken(e))
                .WithMessage("That email address is taken");
        }

        private void SetRulesForPhoneNumber()
        {
            RuleFor(r => r.PhoneNumber)
                .Must(p => p is null || p.Length == 0 || (p.Length == 9
                      && p.ContainsOnlyDigits()))
                .WithMessage("This is not a valid phonenumber");
        }

        private void SetRulesForRoleName()
        {
            RuleFor(r => r.RoleName)
                .NotEmpty()
                .WithMessage("Rolename must not be empty");

            RuleFor(r => r.RoleName)
                .Must(r => _allowedReleNames.Contains(r))
                .WithMessage($"Role name must be in [{string.Join(SEPARATOR, _allowedReleNames)}]");
        }

        private void SetRulesForCountry()
        {
            RuleFor(r => r.Country)
                .MaximumLength(30)
                .WithMessage("Maximum length of country is 30 characters");

            RuleFor(r => r.Country)
                .NotEmpty()
                .WithMessage("Country must not be empty");
        }

        private void SetRulesForCity()
        {
            RuleFor(r => r.City)
                .MaximumLength(30)
                .WithMessage("Maximum length of City is 30 characters");

            RuleFor(r => r.City)
                .NotEmpty()
                .WithMessage("City must not be empty");
        }

        private void SetRulesForStreet()
        {
            RuleFor(r => r.Street)
                .MaximumLength(30)
                .WithMessage("Maximum length of street is 30 characters");

            RuleFor(r => r.Street)
                .NotEmpty()
                .WithMessage("Street must not be empty");
        }

        private void SetRulesForPostalCode()
        {
            RuleFor(r => r.PostalCode)
                .Must(p =>
                {
                    if (p.Length != 6)
                    {
                        return false;
                    }

                    return char.IsDigit(p[0]) &&
                           char.IsDigit(p[1]) &&
                           char.IsDigit(p[3]) &&
                           char.IsDigit(p[4]) &&
                           char.IsDigit(p[5]) &&
                           p[2] == '-';
                })
                .WithMessage("Postalcode must be in format xx-xxx");

            RuleFor(r => r.PostalCode)
                .NotEmpty()
                .WithMessage("Postalcode must not be empty");
        }

        private void SetRulesForPassword()
        {
            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Password must not be empty");

            RuleFor(r => r.Password)
                .MinimumLength(8)
                .WithMessage("Minimum length of the password is 8 characteres");

            RuleFor(r => r.Password)
                .Must(p =>
                {
                    var containsUpper = false;
                    var containsDigit = false;

                    foreach (var c in p)
                    {
                        if (char.IsUpper(c))
                        {
                            containsUpper = true;
                        }
                        else if (char.IsDigit(c))
                        {
                            containsDigit = true;
                        }
                    }

                    return containsUpper && containsDigit;
                })
                .WithMessage("Password must contain minimum one big letter and minimum one digit");
        }

        private void SetRulesForConfirmPassword()
        {
            RuleFor(r => r.ConfirmPassword)
                .Equal(r => r.Password)
                .WithMessage("Confirm password must be equal to password");
        }
    }
}
