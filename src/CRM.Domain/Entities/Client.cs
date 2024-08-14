using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Domain.Entities;

public class Client
{
    [Key]
    public required Guid Id { get; set; }
    
    [MaxLength(50)]
    public required string FirstName { get; set; }
    
    [MaxLength(50)]
    public required string LastName { get; set; }
    
    [MaxLength(15)] // Max length of phone number
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    
    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
    
    [NotMapped]
    public string ShortName => $"{FirstName[0]}. {LastName}";
    
    public virtual Calendar? Calendar { get; set; }
    public virtual Guid? CalendarId { get; set; }

    public virtual List<Booking>? Bookings { get; set; }
}