using AutoMapper;
using AutoMapper.QueryableExtensions;
using Serdiuk.Booking.Domain;
using Serdiuk.Booking.Domain.Dto;

namespace Serdiuk.Booking.Application.Common.Extension
{
    public static class HotelExtensions
    {
        
        public static IQueryable<Hotel> FilterBy(this IQueryable<Hotel> hotels, IMapper mapper,
                                                        NumberType? numberType = null, decimal?
                                                        minCost = null, decimal? maxCost = null)
        {
            var result = hotels;
            if (numberType.HasValue)
            {
                result = result.Where(hotel => hotel.HotelNumbers.Any(n => n.Type == numberType));
            }
            if (minCost.HasValue)
            {
                result = result.Where(h=>h.HotelNumbers.Any(n=>n.NumberCost >= minCost));
            }
            if (maxCost.HasValue)
            {
                result = result.Where(h => h.HotelNumbers.Any(n => n.NumberCost <= maxCost));
            }
            return result;
        }

    }
}
