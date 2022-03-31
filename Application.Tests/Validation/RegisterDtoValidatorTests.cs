using Application.Dtos;
using Application.Tests.Helpers;
using Application.Validation;
using Domain.Interfaces;
using FluentAssertions;
using Moq;
using System;
using Testing.Attributes;
using Xunit;
using Xunit.Abstractions;

namespace Application.Tests.Validation
{
    public class RegisterDtoValidatorTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public RegisterDtoValidatorTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [FromJsonData(typeof(RegisterDto), 
            @"C:\Users\pawel\OneDrive\Pulpit\MyProgramming\MyProjects\BookShop\Application.Tests\DataFiles\ValidRegisterDtos.json",
            false)]
        public void Validate_ForValidModels_ValidationIsSucceed(RegisterDto model)
        {
            var validator = GetValidatorEmailValid();

            var result = validator.Validate(model);
            _testOutputHelper.LogValidationErrorsIfExist(result);

            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [FromJsonData(typeof(RegisterDto),
            @"C:\Users\pawel\OneDrive\Pulpit\MyProgramming\MyProjects\BookShop\Application.Tests\DataFiles\InvalidRegisterDtos.json",
            false)]
        public void Validate_ForInvalidModel_ValidationIsNotSucceed(RegisterDto model)
        {
            var validator = GetValidatorEmailValid();

            var result = validator.Validate(model);
            _testOutputHelper.LogValidationErrorsIfExist(result);

            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Validate_ForTakenEmail_ValidationIsNotSucceed()
        {
            var model = new RegisterDto("Name", "Name", new DateTime(2000, 1, 1), "valid@email.com", "987654321",
                "Admin", "Poland", "Poznań", "Street 13", "00-000", "Password123", "Password123");
            var validator = GetValidatorEmailInvalid();

            var result = validator.Validate(model);
            _testOutputHelper.LogValidationErrorsIfExist(result);

            result.IsValid.Should().BeFalse();
        }

        private RegisterDtoValidator GetValidatorEmailValid()
        {
            var emailValidationHelperMock = new Mock<IEmailValidationHelper>();
            emailValidationHelperMock.Setup(m => m.IsEmailTaken(It.IsAny<string>())).Returns(false);

            return new RegisterDtoValidator(emailValidationHelperMock.Object);
        }

        private RegisterDtoValidator GetValidatorEmailInvalid()
        {
            var emailValidationHelperMock = new Mock<IEmailValidationHelper>();
            emailValidationHelperMock.Setup(m => m.IsEmailTaken(It.IsAny<string>())).Returns(true);

            return new RegisterDtoValidator(emailValidationHelperMock.Object);
        }
    }
}
