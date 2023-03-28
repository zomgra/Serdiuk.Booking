using Serdiuk.Booking.Domain;

namespace Serdiuk.Booking.Application.Common.Extension
{
    public static class HotelExtensions
    {
        public static IQueryable<Hotel> FilterByType(this IQueryable<Hotel> hotels, NumberType type)
        {
            return hotels.Where(hotel => hotel.HotelNumbers.Any(n => n.Type == type));
        }
        public static IQueryable<Hotel> FilterByMinCost(this IQueryable<Hotel> hotels, decimal cost)
        {
            return hotels = hotels.Where(h => h.HotelNumbers.Any(n => n.NumberCost >= cost));
        }
        public static IQueryable<Hotel> FilterByMaxCost(this IQueryable<Hotel> hotels, decimal cost)
        {
            return hotels = hotels.Where(h => h.HotelNumbers.Any(n => n.NumberCost <= cost));
        }
    }
}
