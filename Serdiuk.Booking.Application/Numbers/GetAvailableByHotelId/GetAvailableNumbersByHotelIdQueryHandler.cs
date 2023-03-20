using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Booking.Domain;
using Serdiuk.Booking.Infrastructure.Interfaces;

namespace Serdiuk.Booking.Application.Numbers.GetAvailableByHotelId
{
    public class GetAvailableNumbersByHotelIdQueryHandler : IRequestHandler<GetAvailableNumbersByHotelIdQuery, Result<IEnumerable<HotelNumber>>>
    {
        private readonly IApplicationDbContext _context;
        public GetAvailableNumbersByHotelIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<HotelNumber>>> Handle(GetAvailableNumbersByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _context.Hotels.Include(h=>h.HotelNumbers).FirstOrDefaultAsync(h=>h.Id == request.HotelId, cancellationToken);

            if (hotel == null)
                return Result.Fail("Был введен не правлильный идентификатор отеля");

            var entities = hotel.HotelNumbers.Where(n => n.IsAvailable);
            if (!entities.Any())
                return Result.Fail("Свободных номеров в этом отеле нету");

            return entities.ToResult<IEnumerable<HotelNumber>>();
        }
    }
}
