namespace Serdiuk.Booking.Domain.Dto
{
    public class HotelInfoDto
    {
        /// <summary>
        /// Идентификатор отеля
        /// </summary>
        public int Id { get; init; }
        /// <summary>
        /// Название отеля
        /// </summary>
        public string Name { get; init; }
        /// <summary>
        /// Улица отеля
        /// </summary>
        public string Street { get; init; }
        /// <summary>
        /// Картинка отеля
        /// </summary>
        public string Image { get; init; }
        /// <summary>
        /// Детали отеля
        /// </summary>
        public string Details { get; init; }
        /// <summary>
        /// Количесто номеров
        /// </summary>
        public int NumbersCount { get; init; }
        /// <summary>
        /// Количество свободных номеров
        /// </summary>
        public int AvailableRooms { get; set; }
        /// <summary>
        /// Флаг, можно ли заказать номер в отеле
        /// </summary>
        public bool CanOrderNumber
        {
            get
            {
                return AvailableRooms > 0;
            }
        }
    }
}
