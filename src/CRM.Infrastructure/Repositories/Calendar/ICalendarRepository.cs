namespace CRM.Infrastructure.Repositories.Calendar;

public interface ICalendarRepository
{
    Task<IList<Domain.Entities.Calendar>> GetAllForUserAsync(Guid userId);
    Task<Domain.Entities.Calendar?> GetFromUserAsync(Guid userId, Guid calendarId);
    Task<Domain.Entities.Calendar?> GetById(Guid calendarId);
}