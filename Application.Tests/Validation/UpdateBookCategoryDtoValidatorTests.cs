using Application.Dtos;
using Application.Tests.Helpers;
using Application.Validation;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Application.Tests.Validation
{
    public class UpdateBookCategoryDtoValidatorTests : IClassFixture<UpdateBookCategoryDtoValidator>
    {
        private readonly UpdateBookCategoryDtoValidator _validator;
        private readonly ITestOutputHelper _testOutputHelper;

        public UpdateBookCategoryDtoValidatorTests(UpdateBookCategoryDtoValidator validator, ITestOutputHelper testOutputHelper)
        {
            _validator = validator;
            _testOutputHelper = testOutputHelper;
        }

        public static IEnumerable<object[]> GetModelsWithResults()
        {
            yield return new object[] { new UpdateBookCategoryDto(string.Empty), false };
            yield return new object[] { new UpdateBookCategoryDto(null), false };
            yield return new object[]
            { new UpdateBookCategoryDto("Toooooo loooooooooooooooong naaassssssssame"), false };
            yield return new object[] { new UpdateBookCategoryDto("Good name"), true };
        }

        [Theory]
        [MemberData(nameof(GetModelsWithResults))]
        public void Validate_ForGivenModel_ReturnsProperValidationResult(UpdateBookCategoryDto model, bool shouldBeValid)
        {
            var result = _validator.Validate(model);

            _testOutputHelper.LogValidationErrorsIfExist(result);

            result.IsValid.Should().Be(shouldBeValid);
        }
    }
}
