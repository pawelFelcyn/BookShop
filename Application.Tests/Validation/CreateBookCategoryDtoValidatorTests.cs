using Application.Dtos;
using Application.Tests.Helpers;
using Application.Validation;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Application.Tests.Validation
{
    public class CreateBookCategoryDtoValidatorTests : IClassFixture<CreateBookCategoryDtoValidator>
    {
        private readonly CreateBookCategoryDtoValidator _validator;
        private readonly ITestOutputHelper _testOutputHelper;

        public CreateBookCategoryDtoValidatorTests(CreateBookCategoryDtoValidator validator, ITestOutputHelper testOutputHelper)
        {
            _validator = validator;
            _testOutputHelper = testOutputHelper;
        }

        public static IEnumerable<object[]> GetModelsWithResults()
        {
            yield return new object[] { new CreateBookCategoryDto(string.Empty), false };
            yield return new object[] { new CreateBookCategoryDto(null), false };
            yield return new object[] 
            { new CreateBookCategoryDto("Toooooo loooooooooooooooong naaassssssssame"), false };
            yield return new object[] {new CreateBookCategoryDto("Good name"), true};
        }

        [Theory]
        [MemberData(nameof(GetModelsWithResults))]
        public void Validate_ForGivenModel_ReturnsProperValidationResult(CreateBookCategoryDto model, bool shouldBeValid)
        {
            var result = _validator.Validate(model);

            _testOutputHelper.LogValidationErrorsIfExist(result);

            result.IsValid.Should().Be(shouldBeValid);
        }
    }
}
