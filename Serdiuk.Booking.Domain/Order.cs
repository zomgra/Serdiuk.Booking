using FluentResults;

namespace Serdiuk.Booking.Domain
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        public Order(Guid userId, int numberId, decimal numberCost, DateTime dateStart, DateTime dateEnd)
        {
            if (dateEnd <= dateStart)
                 throw new ArgumentException("Дата выезда не может быть меньше даты заезда");

            UserId = userId;
            NumberId = numberId;
            NumberCost = numberCost;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Status = OrderStatus.Open;
        }
        /// <summary>
        /// Идентификатор заказа
        /// </summary>
        public int OrderId { get; init; }
        /// <summary>
        /// Идентификатор номера
        /// </summary>
        public int NumberId { get; init; }
        /// <summary>
        /// Иденттификатор пользователя
        /// </summary>
        public Guid UserId { get; init; }
        /// <summary>
        /// Статус заказа
        /// </summary>
        public OrderStatus Status { get; private set; }
        /// <summary>
        /// Цена номера
        /// </summary>
        public decimal NumberCost { get; init; }
        /// <summary>
        /// Дата вьезда
        /// </summary>
        public DateTime DateStart { get; init; }
        /// <summary>
        /// Дата выезда
        /// </summary>
        public DateTime DateEnd { get; init; }
        /// <summary>
        /// Количество дней, проведенных в номере
        /// </summary>
        public TimeSpan DayCount 
        {
            get
            {
                return DateEnd - DateStart;
            }
        }
        /// <summary>
        /// Общая сума заказа
        /// </summary>
        public decimal CostOrder 
        {
            get 
            {
                return NumberCost * (decimal)DayCount.TotalDays;
            }
        }

        public Result PayOrder()
        {
            if (Status != OrderStatus.Open)
                return Result.Fail("Произошла ошибка, попробуйте позже");
            
            Status = OrderStatus.Payed;
            return Result.Ok();
        }
    }
}
