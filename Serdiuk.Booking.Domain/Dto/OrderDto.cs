using Serdiuk.Booking.Domain;

namespace Serdiuk.Booking.Domain.Dto
{
    /// <summary>
    /// ДТО заказа
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Статус заказа
        /// </summary>
        public OrderStatus Status { get; set; }
        /// <summary>
        /// Цена номера
        /// </summary>
        public decimal NumberCost { get; init; }
        /// <summary>
        /// Дата вьезда
        /// </summary>
        public string DateStart { get; init; }
        /// <summary>
        /// Дата выезда
        /// </summary>
        public string DateEnd { get; init; }
        /// <summary>
        /// Количество дней, проведенных в номере
        /// </summary>
        public string DayCount { get; init; }
        /// <summary>
        /// Общая сума заказа
        /// </summary>
        public decimal CostOrder { get; init; }
    }
}
