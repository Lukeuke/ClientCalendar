namespace CRM.Application.DTOs.Identity.SignIn;

public record TokenResponseDto(string Token, int ExpiresIn);