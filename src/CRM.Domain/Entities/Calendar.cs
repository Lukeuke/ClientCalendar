using System.ComponentModel.DataAnnotations;

namespace CRM.Domain.Entities;

public class Calendar
{
    [Key]
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required long CreatedAt { get; set; }
    
    [UseSorting]
    [UseFiltering]
    public virtual User Owner { get; set; }
    public virtual Guid OwnerId { get; set; }
    
    [UseSorting]
    [UseFiltering]
    public virtual List<Booking>? Bookings { get; set; }
    [UseSorting]
    [UseFiltering]
    public virtual List<ServiceType>? ServiceTypes { get; set; }
}