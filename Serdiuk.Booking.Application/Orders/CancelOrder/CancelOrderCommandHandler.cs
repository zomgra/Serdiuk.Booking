using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Booking.Infrastructure.Interfaces;

namespace Serdiuk.Booking.Application.Orders.CancelOrder
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, Result>
    {
        private readonly IApplicationDbContext _context;

        public CancelOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == request.OrderId,cancellationToken);

            if (order == null)
                return Result.Fail("Произошла ошибка, заказ не найден, повторите попытку");

            if (order.UserId != request.UserId)
                return Result.Fail("Произошла ошибка, у вас недостаточно прав, повторите попытку");
            var number = await _context.HotelNumbers.FirstOrDefaultAsync(n=>n.NumberId == order.NumberId);

            if (number == null)
                return Result.Fail("Произошла ошибка, заказ не найден, повторите попытку");

            var closeResult = order.TryCloseOrder(number);

            await _context.SaveChangesAsync(cancellationToken);

            return closeResult;
        }
    }
}
