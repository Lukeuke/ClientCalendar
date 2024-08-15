using System.ComponentModel.DataAnnotations;

namespace CRM.Domain.Entities;

public class Booking
{
    [Key]
    public required Guid Id { get; set; }

    public required string Title { get; set; }
    public required long Start { get; set; }
    public required long End { get; set; }
    
    public virtual Client Client { get; set; }
    public virtual required Guid ClientId { get; set; }
        
    public virtual Calendar Calendar { get; set; }
    public virtual required Guid CalendarId { get; set; }
    
    public virtual ServiceType ServiceType { get; set; }
    public virtual required Guid ServiceTypeId { get; set; }
}