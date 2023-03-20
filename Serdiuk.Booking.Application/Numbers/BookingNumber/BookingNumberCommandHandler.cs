using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serdiuk.Booking.Domain;
using Serdiuk.Booking.Infrastructure.Interfaces;

namespace Serdiuk.Booking.Application.Numbers.BookingNumber
{
    public class BookingNumberCommandHandler : IRequestHandler<BookingNumberCommand, Result<Order>>
    {
        private readonly IApplicationDbContext _context;

        public BookingNumberCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Result<Order>> Handle(BookingNumberCommand request, CancellationToken cancellationToken)
        {
            var number = await _context.HotelNumbers.FirstOrDefaultAsync(n => n.NumberId == request.NumberId, cancellationToken);
            if (number == null)
                return Result.Fail("Номер не найден");

            var order = number.BookingNumber(request.UserId, request.NumberId, request.DateStart, request.DateEnd);
            if (order.IsFailed)
            {
                return Result.Fail(order.Reasons.Select(r=>r.Message));
            }
            await _context.Orders.AddAsync(order.Value);
            await _context.SaveChangesAsync(cancellationToken);

            return order;
        }
    }
}
