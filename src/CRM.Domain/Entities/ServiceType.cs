using System.ComponentModel.DataAnnotations;

namespace CRM.Domain.Entities;

public class ServiceType
{
    [Key]
    public required Guid Id { get; set; }

    public required string Name { get; set; }
    public required decimal Price { get; set; }

    public Calendar Calendar { get; set; }
    public required Guid CalendarId { get; set; }
}