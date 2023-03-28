using FluentResults;
using MediatR;
using Serdiuk.Booking.Domain;
using System.Text.Json.Serialization;

namespace Serdiuk.Booking.Application.Numbers.GetAvailableByHotelId
{
    /// <summary>
    /// Запрос на показ всех свободных номеров по идентификатору отеля
    /// </summary>
    public class GetNumbersByHotelIdQuery : IRequest<Result<IEnumerable<HotelNumber>>>
    {
        /// <summary>
        /// Идентификатор отеля
        /// </summary>
        [JsonPropertyName("id")]
        public int HotelId { get; set; }
    }
}
