using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Booking.Domain.Dto;
using Serdiuk.Booking.Infrastructure.Interfaces;


namespace Serdiuk.Booking.Application.Hotels.GetByFilter
{
    public class GetHotelsByFilterQueryHandler : IRequestHandler<GetHotelsByFilterQuery, Result<IEnumerable<HotelInfoDto>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public GetHotelsByFilterQueryHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Result<IEnumerable<HotelInfoDto>>> Handle(GetHotelsByFilterQuery request, CancellationToken cancellationToken)
        {
            var hotels = _context.Hotels.AsNoTracking().Include(g => g.HotelNumbers);

            if (request.MaxCost == 0 && request.MinCost == 0)
            {
                //var results = await hotels.ProjectTo<HotelInfoDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
                var results = _mapper.Map<List<HotelInfoDto>>(hotels);
                return results.ToResult<IEnumerable<HotelInfoDto>>();
            }

            var entities = hotels.ToList()
             .Where(hotel => hotel.CanOrderNumber &&
                    hotel.HotelNumbers.Any(number =>
                        number.NumberCost >= request.MinCost &&
                        number.NumberCost <= request.MaxCost &&
                        number.IsAvailable &&
                        number.Type == request.NumberType));

            //  var result = await entities.ProjectTo<HotelInfoDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            var result = _mapper.Map<List<HotelInfoDto>>(entities);

            return result.ToResult<IEnumerable<HotelInfoDto>>();
        }
    }
}
