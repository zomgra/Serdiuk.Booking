namespace Serdiuk.Booking.Api.Controllers.Dtos.Order
{
    /// <summary>
    /// Дто для команды по отмены заказа
    /// </summary>
    public class CancelOrderCommandDto
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }
    }
}
