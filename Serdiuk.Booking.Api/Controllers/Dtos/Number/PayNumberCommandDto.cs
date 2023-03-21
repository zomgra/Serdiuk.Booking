using System.Text.Json.Serialization;

namespace Serdiuk.Booking.Api.Controllers.Dtos.Number
{
    public class PayNumberCommandDto
    {
        /// <summary>
        /// Идентификатор номера
        /// </summary>
        [JsonPropertyName("numberId")]
        public int NumberId { get; set; }
    }
}
