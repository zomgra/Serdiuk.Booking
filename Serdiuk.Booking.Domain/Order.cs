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

            if (dateStart <= DateTime.Today.AddHours(4))
                throw new ArgumentException("Дата въезда менее или равна сегоднешней дате");

            UserId = userId;
            NumberId = numberId;
            NumberCost = numberCost;
            DateStart = dateStart;
            DateEnd = dateEnd;
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
        /// Флаг, заказан ли номер в отеле
        /// </summary>
        public bool IsPayed { get; private set; }
        /// <summary>
        /// Флаг, закрыт ли заказ
        /// </summary>
        public bool IsClosed { get; private set; }
        /// <summary>
        /// Статус заказа
        /// </summary>
        public OrderStatus Status
        {
            get
            {
                if (DateTime.UtcNow > DateStart || IsClosed)
                    return OrderStatus.Closed;

                if (IsPayed)
                    return OrderStatus.Payed;

                if (DateTime.UtcNow > DateEnd)
                    return OrderStatus.Ended;

                return OrderStatus.Open;
            }
        }
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
        /// <summary>
        /// Оплатить заказ
        /// </summary>
        public Result PayOrder()
        {
            if (Status != OrderStatus.Open)
                return Result.Fail("Произошла ошибка, попробуйте позже");

            IsPayed = true;

            return Result.Ok();
        }
        /// <summary>
        /// Закрыть заказ
        /// </summary>
        /// <returns>Если заказ оплачен, отменен или закончен - вернет Fail</returns>
        public Result TryCloseOrder()
        {
            if (Status != OrderStatus.Open)
                return Result.Fail("Не возможно закрыть заказ, или произошла ошибка");

            IsClosed = true;
            return Result.Ok();
        }
    }
}
