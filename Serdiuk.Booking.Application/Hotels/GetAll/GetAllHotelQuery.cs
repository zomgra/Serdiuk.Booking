using FluentResults;
using MediatR;
using Serdiuk.Booking.Domain;

namespace Serdiuk.Booking.Application.Hotels.GetAll
{
    public class GetAllHotelQuery : IRequest<Result<IEnumerable<Hotel>>>
    {

    }
}
