using FluentResults;
using MediatR;
using Serdiuk.Booking.Domain.Dto;

namespace Serdiuk.Booking.Application.Hotels.GetAll
{
    public class GetAllHotelQuery : IRequest<Result<IEnumerable<HotelInfoDto>>>
    {

    }
}
