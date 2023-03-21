using FluentResults;
using MediatR;
using System.Text.Json.Serialization;

namespace Serdiuk.Booking.Application.Orders.CancelOrder
{
    /// <summary>
    /// Команда по отмене заказа
    /// </summary>
    public class CancelOrderCommand : IRequest<Result>
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [JsonPropertyName("userId")]
        public Guid UserId { get; set; }
    }
}
