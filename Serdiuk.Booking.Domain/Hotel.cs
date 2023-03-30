namespace Serdiuk.Booking.Domain
{
    /// <summary>
    ///  Отель
    /// </summary>
    public class Hotel
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
        /// Детали отеля
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// Картинка отеля
        /// </summary>
        public string Image { get; init; }
        /// <summary>
        /// Количесто номеров
        /// </summary>
        public int NumbersCount
        { get
            {
                return HotelNumbers.Count();
            }
        }
        /// <summary>
        /// Количество свободных номеров
        /// </summary>
        public int AvailableRooms
        {
            get
            {
                return HotelNumbers.Count(n => n.IsAvailable);
            }
        }
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
        /// <summary>
        /// Номера отеля
        /// </summary>
        public virtual ICollection<HotelNumber> HotelNumbers { get; set; }
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="name">Название отеля</param>
        /// <param name="street">Улица отеля</param>
        /// <param name="details">Детали отеля</param>
        public Hotel(string name, string street, string image, string details)
        {
            Name = name;
            Image = image;
            Street = street;
            HotelNumbers = new List<HotelNumber>();
            Details = details;
        }
    }
}
