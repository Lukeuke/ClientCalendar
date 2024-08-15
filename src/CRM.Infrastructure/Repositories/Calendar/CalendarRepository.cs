using CRM.Infrastructure.Context;
using CRM.Infrastructure.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories.Calendar;

public class CalendarRepository : BaseRepository<Domain.Entities.Calendar>, ICalendarRepository
{
    public CalendarRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IList<Domain.Entities.Calendar>> GetAllForUserAsync(Guid userId)
    {
        return await _context.Calendars
            .Include(x => x.Owner)
            .Include(x => x.Bookings)!.ThenInclude(x => x.Client)
            .Include(x => x.ServiceTypes)
            .Where(x => x.OwnerId == userId)
            .ToListAsync();
    }

    public async Task<Domain.Entities.Calendar?> GetFromUserAsync(Guid userId, Guid calendarId)
    {
        var calendar = await _context.Calendars
            .Include(x => x.Owner)
            .Include(x => x.Bookings)!.ThenInclude(x => x.Client)
            .Include(x => x.ServiceTypes)
            .FirstOrDefaultAsync(x => x.Id == calendarId && x.OwnerId == userId);

        return calendar;
    }

    public async Task<Domain.Entities.Calendar?> GetById(Guid calendarId)
    {
        return await _context.Calendars
            .Include(x => x.Owner)
            .Include(x => x.Bookings)!.ThenInclude(x => x.Client)
            .Include(x => x.ServiceTypes)
            .FirstOrDefaultAsync(x => x.Id == calendarId);

    }
}