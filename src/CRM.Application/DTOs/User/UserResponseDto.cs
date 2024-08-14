namespace CRM.Application.DTOs.User;

public record UserResponseDto(Guid Id, string FirstName, string LastName, string Email, long CreatedAt);