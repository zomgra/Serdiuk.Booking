using FluentResults;
using System.ComponentModel.DataAnnotations;
namespace Serdiuk.Booking.Domain
{
    /// <summary>
    /// Номер
    /// </summary>
    public class HotelNumber
    {
        public HotelNumber(string name, string image, NumberType type, decimal numberCost)
        {
            Name = name;
            Image = image;
            Type = type;
            NumberCost = numberCost;
            IsAvailable = true;
            IsPopulated = false;
        }
        /// <summary>
        /// Идентификатор номера
        /// </summary>
        [Key]
        public int NumberId { get; init; }
        /// <summary>
        /// Название номера
        /// </summary>
        public string Name { get; init; }
        /// <summary>
        /// Флаг, заселен ли кто-то в отель
        /// </summary>
        public bool IsPopulated { get; set; }
        /// <summary>
        /// Флаг, свободен ли номер, и можно ли его заказать
        /// </summary>
        public bool IsAvailable { get; private set; }
        /// <summary>
        /// Картинка номера
        /// </summary>
        public string Image { get; init; }
        /// <summary>
        /// Тип номера
        /// </summary>
        public NumberType Type { get; set; }
        /// <summary>
        /// Цена номера
        /// </summary>
        public decimal NumberCost { get; init; }

        /// <summary>
        /// Заказать номер
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="dateStart">Дата вьезда</param>
        /// <param name="dateEnd">Дата выезда</param>
        /// <returns></returns>
        public Result<Order> BookingNumber(Guid userId, int numberId, DateTime dateStart, DateTime dateEnd)
        {
            if (!IsAvailable && !IsPopulated)
                return Result.Fail("Этот номер сейчас не свободен");
            try
            {
                var order = new Order(userId, numberId, NumberCost, dateStart, dateEnd);
                IsAvailable = false;
                return order.ToResult();
            }
            catch (ArgumentException e)
            {
                return Result.Fail(e.Message);
            }
        }
        public Result BookRoom()
        {
            if (IsAvailable)
                return Result.Fail("Произошла ошибка, номер не заказан");

            IsPopulated = true;
            return Result.Ok();
        }
    }
}
