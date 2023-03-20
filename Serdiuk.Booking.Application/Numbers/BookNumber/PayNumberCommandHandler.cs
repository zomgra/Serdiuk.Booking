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
            var number = await _context.HotelNumbers.FirstOrDefaultAsync(n => n.NumberId == request.NumberId, cancellationToken);

            if (number == null)
                return Result.Fail("Произошла ошибка, повторите позже");

            var payedResult = number.BookRoom();

            await _context.SaveChangesAsync(cancellationToken);

            return payedResult;
        }
    }
}
