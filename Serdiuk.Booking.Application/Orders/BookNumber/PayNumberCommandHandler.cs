using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Booking.Infrastructure.Interfaces;

namespace Serdiuk.Booking.Application.Numbers.BookNumber
{
    public class PayNumberCommandHandler : IRequestHandler<PayNumberCommand, Result>
    {
        private readonly IApplicationDbContext _context;

        public PayNumberCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(PayNumberCommand request, CancellationToken cancellationToken)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(n => n.OrderId == request.OrderId, cancellationToken);

            if (order == null)
                return Result.Fail("Произошла ошибка, повторите позже");

            var payedResult = order.PayOrder();

            await _context.SaveChangesAsync(cancellationToken);

            return payedResult;
        }
    }
}
