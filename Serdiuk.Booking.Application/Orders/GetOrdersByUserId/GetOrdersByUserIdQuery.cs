using FluentResults;
using MediatR;
using Serdiuk.Booking.Domain.Dto;

namespace Serdiuk.Booking.Application.Orders.GetOrdersByUserId
{
    public class GetOrdersByUserIdQuery : IRequest<Result<IEnumerable<OrderDto>>>
    {
        public Guid UserId { get; set; }
    }
}
