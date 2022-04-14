using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Application.Dtos;
using Testing.Extensions;
using System.Net;
using FluentAssertions;
using System;
using Application.Services;
using Moq;
using System.Collections.Generic;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;

namespace API.Tests.Controllers
{
    public class AccountsControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private WebApplicationFactory<Startup> _factory;

        public AccountsControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var descriptor = services.SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<BookShopDbContext>));

                    services.Remove(descriptor);
                    services.AddDbContext<BookShopDbContext>(options => options.UseInMemoryDatabase("BookShopDb"));
                });
            });
        }

        public static IEnumerable<object[]> LoginInvalidContentOrBadEmailData()
        {
            yield return new object[] { new LoginDto(null, null) };
            yield return new object[] { new LoginDto("notexists", "Password123") };
        }

        [Fact]
        public async Task Register_ForInvalidModel_ReturnsBadRequestStatusCode()
        {
            var model = new RegisterDto(null, null, null, null, null, null, null, null, null,
                null, null, null);
            var content = model.GetJsonContent();
            var client = _factory.CreateClient();

            var response = await client.PostAsync("/api/Accounts/register", content);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Register_ForValidModel_ReturnsOkStatusCode()
        {
            var model = new RegisterDto("Name", "Name", new DateTime(2000, 1, 1), "email@email.com", "987654321",
                "Admin", "Poland", "XDDD", "XDDD", "00-000", "Password123", "Password123");
            var content = model.GetJsonContent();
            var client = _factory.CreateClient();

            var response = await client.PostAsync("/api/Accounts/register", content);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Login_ForGoodEmailAndPassword_ReturnsOkStatusCode()
        {
            var model = new LoginDto("email@email.com", "Password123");
            var content = model.GetJsonContent();
            const string TOKEN = "Jwt token";
            var serviceMock = new Mock<IAccountService>();
            var factory = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var service = services.SingleOrDefault(s => s.ServiceType == typeof(IAccountService));

                    services.Remove(service);
                    services.AddSingleton(serviceMock.Object);
                });
            });
            serviceMock.Setup(m => m.GetToken(It.IsAny<LoginDto>())).Returns(TOKEN);
            var client = factory.CreateClient();

            var response = await client.PostAsync("/api/Accounts/login", content);
            var responseContent = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseContent.Should().Be(TOKEN);
        }

        [Theory]
        [MemberData(nameof(LoginInvalidContentOrBadEmailData))]
        public async Task Login_InvalidContentOrBadEmail_ReturnsBadRequestStatusCode(LoginDto model)
        {
            var content = model.GetJsonContent();

            var client = _factory.CreateClient();

            var response = await client.PostAsync("/api/Accounts/login", content);

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Login_ForBadPassword_ReturnsBadRequestStatusCode()
        {
            var repositoryMock = new Mock<IAccountRepository>();
            var passwordHasherMock = new Mock<IPasswordHasher<User>>();
            var model = new LoginDto("email@email.com", "Password123");
            var content = model.GetJsonContent();

            var factory = _factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var repository = services.SingleOrDefault(s => s.ServiceType == typeof(IAccountRepository));
                        var hasher = services.SingleOrDefault(s => s.ServiceType == typeof(IPasswordHasher<User>));

                        services.Remove(repository);
                        services.Remove(hasher);

                        services.AddSingleton(repositoryMock.Object);
                        services.AddSingleton(passwordHasherMock.Object);
                    });
                });

            repositoryMock.Setup(m => m.GetByEmail(It.IsAny<string>())).Returns(new User());
            passwordHasherMock.Setup(m => m.VerifyHashedPassword(It.IsAny<User>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(PasswordVerificationResult.Failed);

            var client = factory.CreateClient();

            var response = await client.PostAsync("/api/Accounts/login", content); ;

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
