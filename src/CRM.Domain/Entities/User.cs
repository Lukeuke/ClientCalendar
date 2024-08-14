using System.ComponentModel.DataAnnotations;

namespace CRM.Domain.Entities;

public class User
{
    [Key]
    public required Guid Id { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string Salt { get; set; }
    
    public required long CreatedAt { get; set; }
    
    public virtual List<Calendar>? Calendars { get; set; }
}