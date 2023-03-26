using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Booking.Application.Common.Extension;
using Serdiuk.Booking.Domain;
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

            if (!request.MaxCost.HasValue && !request.MinCost.HasValue)
            {
                var results = _mapper.Map<List<HotelInfoDto>>(hotels);
                return results.ToResult<IEnumerable<HotelInfoDto>>();
            }
            var entities = hotels.FilterBy(_mapper, request.NumberType, request.MinCost, request.MaxCost);



            var result = entities.ProjectTo<HotelInfoDto>(_mapper.ConfigurationProvider);

            return result.ToResult<IEnumerable<HotelInfoDto>>();
        }
    }
}
