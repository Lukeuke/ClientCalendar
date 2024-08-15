using CRM.Infrastructure.Context;
using CRM.Infrastructure.Repositories.Abstraction;

namespace CRM.Infrastructure.Repositories.Booking;

public class BookingRepository : BaseRepository<Domain.Entities.Booking>
{
    public BookingRepository(ApplicationContext context) : base(context)
    {
    }
}