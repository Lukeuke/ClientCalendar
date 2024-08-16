using CRM.Application.DTOs.Booking.Create;
using CRM.Application.DTOs.Message;
using CRM.Application.Helpers;
using CRM.Domain.Entities;
using CRM.Infrastructure.Context;
using CRM.Infrastructure.Repositories.Abstraction;
using CRM.Infrastructure.Repositories.Calendar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Web.Modules;

public static class BookingModule
{
    public static void AddBookingEndpoint(this WebApplication app)
    {
        app.MapPut("/api/booking", async (
            [FromBody] CreateBookingRequestDto requestDto,
            [FromServices] BaseRepository<Client> clientRepository,
            [FromServices] ICalendarRepository calendarRepository,
            [FromServices] ApplicationContext context, // TODO: refactor into SRP
            [FromHeader] string authorization) =>
            {
                var client = await context.Clients.FirstOrDefaultAsync(x => x.PhoneNumber == requestDto.PhoneNumber);

                if (client is null)
                {
                    client = new Client
                    {
                        Id = Guid.NewGuid(),
                        FirstName = requestDto.Name,
                        LastName = requestDto.Surname,
                        PhoneNumber = requestDto.PhoneNumber,
                        Address = requestDto.Address,
                        CalendarId = requestDto.CalendarId
                    };
                    
                    await clientRepository.AddAsync(client);
                }

                /*
                var service = await context.ServiceTypes
                    .Include(x => x.Calendar).ThenInclude(x => x.Owner)
                    .FirstOrDefaultAsync(x =>
                        x.CalendarId == requestDto.CalendarId && x.Name == requestDto.ServiceType);
                        */

                var service = new ServiceType
                {
                    Id = Guid.NewGuid(),
                    Name = requestDto.ServiceType,
                    Price = requestDto.Price,
                    CalendarId = requestDto.CalendarId
                };

                await context.ServiceTypes.AddAsync(service);
                await context.SaveChangesAsync();

                var jwt = authorization.Split(" ")[^1].DeAssembleClaimsIdentity("id")?.Value;

                if (jwt is null)
                {
                    return Results.BadRequest(new MessageResponseDto("Wrong jwt."));
                }

                var calendar = await calendarRepository.GetById(requestDto.CalendarId);
                
                if (calendar is null)
                {
                    return Results.BadRequest(new MessageResponseDto("Couldn't find calendar with this id."));
                }

                if (calendar.OwnerId != Guid.Parse(jwt))
                {
                    return Results.Forbid();
                }

                var bookingId = Guid.NewGuid();
                var booking = new Booking
                {
                    Id = bookingId,
                    Title = requestDto.ServiceType,
                    Start = ((DateTimeOffset)requestDto.DateStart).ToUnixTimeSeconds(),
                    End = ((DateTimeOffset)requestDto.DateEnd).ToUnixTimeSeconds(),
                    Color = requestDto.Color,
                    ClientId = client.Id,
                    CalendarId = requestDto.CalendarId,
                    ServiceTypeId = service.Id
                };

                await context.Bookings.AddAsync(booking);
                await context.SaveChangesAsync();

                return Results.Created($"/calendar/{requestDto.CalendarId}/details/{bookingId}", null);
            })
            .RequireAuthorization();
    }
}