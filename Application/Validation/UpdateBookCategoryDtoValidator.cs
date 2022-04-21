using Application.Dtos;
using FluentValidation;
using System;

namespace Application.Validation
{
    public class UpdateBookCategoryDtoValidator : AbstractValidator<UpdateBookCategoryDto>
    {
        public UpdateBookCategoryDtoValidator()
        {
            SetRulesForName();
        }

        private void SetRulesForName()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Field name must not be empty");

            RuleFor(u => u.Name)
                .MaximumLength(30)
                .WithMessage("The maximum length of the password is 30 characteres");
        }
    }
}
