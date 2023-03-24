using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Booking.Domain.Dto;
using Serdiuk.Booking.Infrastructure.Interfaces;

namespace Serdiuk.Booking.Application.Hotels.GetAll
{
    public class GetAllHotelQueryHandler : IRequestHandler<GetAllHotelQuery, Result<IEnumerable<HotelInfoDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllHotelQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public async Task<Result<IEnumerable<HotelInfoDto>>> Handle(GetAllHotelQuery request, CancellationToken cancellationToken)
        {
            var hotels = _context.Hotels.AsNoTracking().Include(h => h.HotelNumbers);
            if (!hotels.Any())
                return Result.Fail("Произошла ошибка, повторите попытку");

            var entities = await _mapper.ProjectTo<HotelInfoDto>(hotels).ToListAsync(cancellationToken);
            return entities.ToResult<IEnumerable<HotelInfoDto>>();
        }
    }
}
