namespace Serdiuk.Booking.Domain
{
    /// <summary>
    /// Статус заказа
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Открыт и не оплачен
        /// </summary>
        Open = 0,
        /// <summary>
        /// Оплачен
        /// </summary>
        Payed = 1,
        /// <summary>
        /// Заказавший уже выехал с номера
        /// </summary>
        Ended = 2,
        /// <summary>
        /// Заказ отменен
        /// </summary>
        Closed = 3,
    }
}