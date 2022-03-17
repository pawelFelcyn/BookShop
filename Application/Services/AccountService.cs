using Application.Dtos;
using Application.Exceptions;
using AspNetAuthentication.TokenGeneration;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ITokenGenerator<User> _tokenGenerator;

        public AccountService(IAccountRepository repository, IMapper mapper, IPasswordHasher<User> passwordHasher,
            ITokenGenerator<User> tokenGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _tokenGenerator = tokenGenerator;
        }

        public void Register(RegisterDto dto)
        {
            var user = _mapper.Map<User>(dto);

            var hashedPassword = _passwordHasher.HashPassword(user, dto.Password);
            user.PasswordHash = hashedPassword;
            
            _repository.Add(user);
        }

        public string GetToken(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);

            var authenticationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash,
                dto.Password);

            if (authenticationResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException();
            }

            return _tokenGenerator.GetTokenString(user);
        }
    }
}
