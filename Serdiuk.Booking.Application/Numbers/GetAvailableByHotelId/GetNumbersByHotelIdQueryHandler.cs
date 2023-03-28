using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Booking.Domain;
using Serdiuk.Booking.Infrastructure.Interfaces;

namespace Serdiuk.Booking.Application.Numbers.GetAvailableByHotelId
{
    public class GetNumbersByHotelIdQueryHandler : IRequestHandler<GetNumbersByHotelIdQuery, Result<IEnumerable<HotelNumber>>>
    {
        private readonly IApplicationDbContext _context;
        public GetNumbersByHotelIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<HotelNumber>>> Handle(GetNumbersByHotelIdQuery request, CancellationToken cancellationToken)
        {
            var hotel = await _context.Hotels.Include(h=>h.HotelNumbers).FirstOrDefaultAsync(h=>h.Id == request.HotelId, cancellationToken);

            if (hotel == null)
                return Result.Fail("Был введен не правлильный идентификатор отеля");


            return hotel.HotelNumbers.ToResult<IEnumerable<HotelNumber>>();
        }
    }
}
