namespace CRM.Application.DTOs.Booking.Create;

public record CreateBookingRequestDto(
    Guid CalendarId, 
    string Name, 
    string Surname, 
    string ServiceType, 
    DateTime DateStart, 
    DateTime DateEnd, 
    decimal Price, 
    string PhoneNumber,
    string Address);