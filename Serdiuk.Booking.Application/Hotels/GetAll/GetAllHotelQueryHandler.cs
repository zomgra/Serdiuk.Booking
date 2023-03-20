using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Booking.Domain;
using Serdiuk.Booking.Infrastructure.Interfaces;

namespace Serdiuk.Booking.Application.Hotels.GetAll
{
    public class GetAllHotelQueryHandler : IRequestHandler<GetAllHotelQuery, Result<IEnumerable<Hotel>>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllHotelQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<Hotel>>> Handle(GetAllHotelQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.Hotels.Include(h => h.HotelNumbers).ToArrayAsync(cancellationToken);
            if (!entities.Any())
                return Result.Fail("Произошла ошибка, повторите попытку");
            return entities.ToResult<IEnumerable<Hotel>>();
        }
    }
}
