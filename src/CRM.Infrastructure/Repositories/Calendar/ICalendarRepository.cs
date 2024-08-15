namespace CRM.Infrastructure.Repositories.Calendar;

public interface ICalendarRepository
{
    Task<IList<Domain.Entities.Calendar>> GetAllForUserAsync(Guid userId);
}