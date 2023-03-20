using Microsoft.EntityFrameworkCore;
using Serdiuk.Booking.Domain;

namespace Serdiuk.Booking.Infrastructure.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Hotel> Hotels { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<HotelNumber> HotelNumbers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
