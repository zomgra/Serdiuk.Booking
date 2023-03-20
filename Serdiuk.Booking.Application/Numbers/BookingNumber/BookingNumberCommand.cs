using FluentResults;
using MediatR;
using Serdiuk.Booking.Domain;
using System.Text.Json.Serialization;

namespace Serdiuk.Booking.Application.Numbers.BookingNumber
{
    /// <summary>
    /// Команда заказа номера
    /// </summary>
    public class BookingNumberCommand : IRequest<Result<Order>>
    {
        /// <summary>
        /// Идентификатор номера, который будет заказан
        /// </summary>
        [JsonPropertyName("numberId")]
        public int NumberId { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [JsonPropertyName("userId")]
        public Guid UserId { get; set; }
        /// <summary>
        /// Дата вьезда в отель
        /// </summary>
        [JsonPropertyName("dateStart")]
        public DateTime DateStart { get; set; }
        /// <summary>
        /// Дата выезда с отеля
        /// </summary>
        [JsonPropertyName("dateEnd")]
        public DateTime DateEnd { get; set; }
    }
}
