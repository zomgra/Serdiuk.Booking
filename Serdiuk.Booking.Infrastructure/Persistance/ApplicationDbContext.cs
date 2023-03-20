using Microsoft.EntityFrameworkCore;
using Serdiuk.Booking.Domain;
using Serdiuk.Booking.Infrastructure.Interfaces;

namespace Serdiuk.Booking.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<HotelNumber> HotelNumbers { get; set; }
    }
}
