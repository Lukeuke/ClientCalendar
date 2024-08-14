using System.ComponentModel.DataAnnotations;

namespace CRM.Domain.Entities;

public class Calendar
{
    [Key]
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required long CreatedAt { get; set; }
    
    public virtual User Owner { get; set; }
    public virtual Guid OwnerId { get; set; }
    
    public virtual List<Client>? Clients { get; set; }
    public virtual List<ServiceType>? ServiceTypes { get; set; }
}