using AutoMapper;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Booking.Domain.Dto;
using Serdiuk.Booking.Infrastructure.Interfaces;

namespace Serdiuk.Booking.Application.Orders.GetOrdersByUserId
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Result<IEnumerable<OrderDto>>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrdersByUserIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public async Task<Result<IEnumerable<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Where(o => o.UserId == request.UserId).ToListAsync(cancellationToken);
            if (!orders.Any())
                return Result.Fail("У вас нету заказов");

            List<OrderDto> entities = new List<OrderDto>();

            foreach (var item in orders)
            {
                entities.Add(_mapper.Map<OrderDto>(item));
            }

            return entities.ToResult<IEnumerable<OrderDto>>();
        }
    }
}
