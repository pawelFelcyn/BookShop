using Application.Dtos;
using Application.Tests.Helpers;
using Application.Validation;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Application.Tests.Validation
{
    public class LoginDtoValidatorTests : IClassFixture<LoginDtoValidator>
    {
        private readonly LoginDtoValidator _validator;
        private readonly ITestOutputHelper _testOutputHelper;

        public LoginDtoValidatorTests(LoginDtoValidator validator, ITestOutputHelper testOutputHelper)
        {
            _validator = validator;
            _testOutputHelper = testOutputHelper;
        }

        public static IEnumerable<object[]> GetLoginDtos()
        {
            yield return new object[] { new LoginDto("email@email.com", "Password123"), true };
            yield return new object[] { new LoginDto("email@email.com", ""), false };
            yield return new object[] { new LoginDto("", "Password"), false };
            yield return new object[] { new LoginDto(null, "Password"), false };
            yield return new object[] { new LoginDto("email@email.com", null), false };
        }

        [Theory]
        [MemberData(nameof(GetLoginDtos))]
        public void Validate_ForGivenModel_ReturnsProperValidationResult(LoginDto model, bool expectedResult)
        {
            var result = _validator.Validate(model);

            _testOutputHelper.LogValidationErrorsIfExist(result);

            result.IsValid.Should().Be(expectedResult);
        }
    }
}
