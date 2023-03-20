using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serdiuk.Booking.Infrastructure.Interfaces;
using Serdiuk.Booking.Infrastructure.Persistance;

namespace Serdiuk.Booking.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(c => c.UseInMemoryDatabase("DEV_APPLICATIONDB"));
            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            return services;
        }
    }
}
