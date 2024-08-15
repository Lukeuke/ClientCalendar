using CRM.Application.Helpers;
using CRM.Domain.Entities;
using CRM.Infrastructure.Repositories.Calendar;
using HotChocolate;
using HotChocolate.Authorization;
using Microsoft.AspNetCore.Http;

namespace CRM.Application.Graphql.Queries;

public class CalendarQuery
{
    [Authorize]
    [UseFiltering]
    [UseSorting]
    public async Task<IList<Calendar>> GetAllCalendars(
        [Service] ICalendarRepository calendarRepository,
        [Service] IHttpContextAccessor httpContextAccessor
        )
    {
        var userId = httpContextAccessor.GetUserIdFromJwt();

        return await calendarRepository.GetAllForUserAsync(userId);
    }
    
    [Authorize]
    [UseFiltering]
    [UseSorting]
    public async Task<Calendar?> GetCalendar(
        [Service] ICalendarRepository calendarRepository,
        [Service] IHttpContextAccessor httpContextAccessor,
        Guid id
    )
    {
        var userId = httpContextAccessor.GetUserIdFromJwt();

        return await calendarRepository.GetFromUserAsync(userId, id);
    }
}