using Application.Dtos;
using FluentValidation;
using System;

namespace Application.Validation
{
    public class CreateBookCategoryDtoValidator : AbstractValidator<CreateBookCategoryDto>
    {
        public CreateBookCategoryDtoValidator()
        {
            SetRulesForName();
        }

        private void SetRulesForName()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name must not be empty");

            RuleFor(c => c.Name)
                .MaximumLength(30)
                .WithMessage("The maximum length of name is 30 charascters");
        }
    }
}
