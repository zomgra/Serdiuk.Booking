using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Booking.Domain;
using Serdiuk.Booking.Infrastructure.Interfaces;

namespace Serdiuk.Booking.Application.Orders.GetOrdersByUserId
{
    public class GetOrdersByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, Result<IEnumerable<Order>>>
    {
        private readonly IApplicationDbContext _context;

        public GetOrdersByUserIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<IEnumerable<Order>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders.Where(o => o.UserId == request.UserId).ToListAsync(cancellationToken);
            if (!orders.Any())
                return Result.Fail("У вас нету заказов");
            return orders.ToResult<IEnumerable<Order>>();
        }
    }
}
