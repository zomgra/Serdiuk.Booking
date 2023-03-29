using System.Text.Json.Serialization;

namespace Serdiuk.Booking.Api.Controllers.Dtos.Order
{
    public class PayNumberCommandDto
    {
        /// <summary>
        /// Идентификатор отеля
        /// </summary>
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }
    }
}
