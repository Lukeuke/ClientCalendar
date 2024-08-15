using CRM.Application.DTOs.Calendar.Create;
using CRM.Application.Helpers;
using CRM.Domain.Entities;
using CRM.Infrastructure.Repositories.Abstraction;
using HotChocolate;
using HotChocolate.Authorization;
using Microsoft.AspNetCore.Http;

namespace CRM.Application.Graphql.Mutations;

public class CalendarMutation
{
    [Authorize]
    public async Task<bool> CreateCalendar(
        [Service] BaseRepository<Calendar> calendarRepository,
        [Service] IHttpContextAccessor httpContextAccessor,
        CreateCalendarRequestDto requestDto)
    {
        var authorizationHeader = httpContextAccessor.HttpContext?.Request.Headers["Authorization"];

        if (authorizationHeader is null)
        {
            throw new Exception("Authorization header is missing.");
        }

        var token = authorizationHeader.ToString()?.Split(" ")[^1];

        var userIdClaim = token!.DeAssembleClaimsIdentity("id")?.Value;

        if (userIdClaim is null)
        {
            throw new Exception("Jwt is not valid.");
        }

        var userId = Guid.Parse(userIdClaim);
        
        var calendar = new Calendar
        {
            Id = Guid.NewGuid(),
            Name = requestDto.Name,
            CreatedAt = DateTimeOffset.Now.ToUnixTimeSeconds(),
            OwnerId = userId
        };
        
        var result = await calendarRepository.AddAsync(calendar);

        return result is not null;
    }
}