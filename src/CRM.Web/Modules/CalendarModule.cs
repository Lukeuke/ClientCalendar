using CRM.Application.DTOs.Calendar.Create;
using CRM.Application.Helpers;
using CRM.Domain.Entities;
using CRM.Infrastructure.Repositories.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Modules;

public static class CalendarModule
{
    public static void AddCalendarEndpoint(this WebApplication app)
    {
        app.MapPut("/api/calendar", async (
            [FromServices] BaseRepository<Calendar> calendarRepository,
            [FromHeader] string authorization,
            [FromBody] CreateCalendarRequestDto requestDto
            ) =>
        {
            var userId = authorization.GetUserIdFromJwt();
        
            var calendar = new Calendar
            {
                Id = Guid.NewGuid(),
                Name = requestDto.Name,
                CreatedAt = DateTimeOffset.Now.ToUnixTimeSeconds(),
                OwnerId = userId
            };
        
            var result = await calendarRepository.AddAsync(calendar);

            return result is not null ? Results.Created("/graphql", calendar) : Results.BadRequest();
        })
            .RequireAuthorization();
    }
}