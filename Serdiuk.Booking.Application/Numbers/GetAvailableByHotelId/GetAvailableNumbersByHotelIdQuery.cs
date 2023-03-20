using FluentResults;
using MediatR;
using Serdiuk.Booking.Domain;

namespace Serdiuk.Booking.Application.Numbers.GetAvailableByHotelId
{
    /// <summary>
    /// Запрос на показ всех свободных номеров по идентификатору отеля
    /// </summary>
    public class GetAvailableNumbersByHotelIdQuery : IRequest<Result<IEnumerable<HotelNumber>>>
    {
        /// <summary>
        /// Идентификатор отеля
        /// </summary>
        public int HotelId { get; set; }
    }
}
