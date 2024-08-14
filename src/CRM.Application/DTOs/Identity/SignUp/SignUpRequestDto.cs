namespace CRM.Application.DTOs.Identity.SignUp;

public record SignUpRequestDto(string FirstName, string LastName, string Email, string Password);