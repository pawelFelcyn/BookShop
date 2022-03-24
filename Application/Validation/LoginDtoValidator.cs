using Application.Dtos;
using FluentValidation;
using System;

namespace Application.Validation
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            SetRulesForEmail();
            SetRulesForPassword();
        }

        private void SetRulesForEmail()
        {
            RuleFor(l => l.Email)
                .NotEmpty()
                .WithMessage("Email must not be empty");
        }

        private void SetRulesForPassword()
        {
            RuleFor(l => l.Password)
                .NotEmpty()
                .WithMessage("Password must not be empty");
        }
    }
}
