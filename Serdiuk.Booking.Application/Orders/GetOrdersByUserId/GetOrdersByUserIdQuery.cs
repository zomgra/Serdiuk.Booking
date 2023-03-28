using FluentResults;
using MediatR;
using Serdiuk.Booking.Domain;

namespace Serdiuk.Booking.Application.Orders.GetOrdersByUserId
{
    public class GetOrdersByUserIdQuery : IRequest<Result<IEnumerable<Order>>>
    {
        public Guid UserId { get; set; }
    }
}
