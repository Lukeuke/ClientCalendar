using CRM.Application.DTOs.Identity.SignIn;
using CRM.Application.DTOs.Identity.SignUp;
using CRM.Application.Enums;

namespace CRM.Application.Services.Identity;

public interface IIdentityService
{
    Task<(bool, object)> SignUpAsync(SignUpRequestDto requestDto);
    Task<(EResponseStatusCode, object)> SignInAsync(SignInRequestDto requestDto);
}