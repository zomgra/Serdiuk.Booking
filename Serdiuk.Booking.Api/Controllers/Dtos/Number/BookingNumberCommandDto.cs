using System.Text.Json.Serialization;

namespace Serdiuk.Booking.Api.Controllers.Dtos.Number
{
    public class BookingNumberCommandDto
    {
        /// <summary>
        /// Идентификатор номера, который будет заказан
        /// </summary>
        [JsonPropertyName("numberId")]
        public int NumberId { get; set; }
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
