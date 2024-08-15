using System.ComponentModel.DataAnnotations;

namespace CRM.Domain.Entities;

public class Booking
{
    [Key]
    public required Guid Id { get; set; }

    public required string Title { get; set; }
    public required long StartDate { get; set; }
    public required long EndDate { get; set; }
    
    public virtual required Client Client { get; set; }
    public virtual required Guid ClientId { get; set; }
        
    public virtual required Calendar Calendar { get; set; }
    public virtual required Guid CalendarId { get; set; }
    
    public virtual required ServiceType ServiceType { get; set; }
    public virtual required Guid ServiceTypeId { get; set; }
}