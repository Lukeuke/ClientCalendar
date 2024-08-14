using AutoMapper;
using CRM.Application.DTOs.Identity.SignIn;
using CRM.Application.DTOs.Identity.SignUp;
using CRM.Application.DTOs.Message;
using CRM.Application.DTOs.User;
using CRM.Application.Enums;
using CRM.Application.Helpers;
using CRM.Application.Models;
using CRM.Domain.Entities;
using CRM.Infrastructure.Repositories.Abstraction;
using CRM.Infrastructure.Repositories.Identity;

namespace CRM.Application.Services.Identity;

public class IdentityService : IIdentityService
{
    private readonly IIdentityRepository _repository;
    private readonly BaseRepository<User> _userRepository;
    private readonly IMapper _mapper;
    private readonly Settings _settings;

    public IdentityService(
        IIdentityRepository repository,
        BaseRepository<User> userRepository,
        IMapper mapper,
        Settings settings)
    {
        _repository = repository;
        _userRepository = userRepository;
        _mapper = mapper;
        _settings = settings;
    }
    
    public async Task<(bool, object)> SignUpAsync(SignUpRequestDto requestDto)
    {
        var isUser = await _repository.GetUserByEmailAsync(requestDto.Email);

        if (isUser is not null)
        {
            return (false, new MessageResponseDto("Email is already in use."));
        }
        
        // TODO: Add fluent validation (Email PhoneNumber)

        var userId = Guid.NewGuid();
        
        var user = new User
        {
            Id = userId,
            FirstName = requestDto.FirstName,
            LastName = requestDto.LastName,
            PasswordHash = requestDto.Password,
            Email = requestDto.Email,
            Salt = "",
            CreatedAt = DateTimeOffset.Now.ToUnixTimeSeconds()
        };

        user.ProvideSaltAndHash();

        try
        {
            await _userRepository.AddAsync(user);

            var response = _mapper.Map<UserResponseDto>(user);
            
            return (true, response);
        }
        catch
        {
            return (false, new MessageResponseDto("Failed to create user."));
        }
    }

    public async Task<(EResponseStatusCode, object)> SignInAsync(SignInRequestDto requestDto)
    {
        var user = await _repository.GetUserByEmailAsync(requestDto.Email);

        if (user is null)
        {
            return (EResponseStatusCode.NotFound, new MessageResponseDto("Couldn't find a user with this email."));
        }

        if (user.PasswordHash != AuthenticationHelper.GenerateHash(requestDto.Password, user.Salt))
        {
            return (EResponseStatusCode.BadRequest, new MessageResponseDto("Password is not valid."));
        }

        // var userClaimsModel = _mapper.Map<UserClaimsModel>(user);
        
        var token = AuthenticationHelper.GenerateJwt(AuthenticationHelper.AssembleClaimsIdentity(user), _settings);
        
        return (EResponseStatusCode.Ok, new TokenResponseDto(token, _settings.Expiration));
    }
}