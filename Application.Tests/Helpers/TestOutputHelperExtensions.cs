using FluentValidation.Results;
using Xunit.Abstractions;

namespace Application.Tests.Helpers
{
    internal static class TestOutputHelperExtensions
    {
        public static void LogValidationErrorsIfExist(this ITestOutputHelper testOutputHelper, ValidationResult validationResult)
        {
            foreach (var e in validationResult.Errors)
            {
                testOutputHelper.WriteLine(e.ErrorMessage);
            }
        }
    }
}
