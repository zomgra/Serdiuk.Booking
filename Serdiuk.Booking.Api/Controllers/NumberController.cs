using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serdiuk.Booking.Api.Controllers.Dtos.Number;
using Serdiuk.Booking.Application.Numbers.BookingNumber;
using Serdiuk.Booking.Application.Numbers.BookNumber;
using Serdiuk.Booking.Application.Numbers.GetAvailableByHotelId;

namespace Serdiuk.Booking.Api.Controllers
{
    /// <summary>
    /// Контроллер по работе с номерами отеля
    /// </summary>
    [ApiController]
    //[Authorize]
    [Route("api/v1/hotel/numbers")]
    public class NumberController : BaseControllerApi
    {
        /// <summary>
        /// Получить все доступные отели по идентификатору отеля
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAvailableNumberByHotelId([FromQuery] GetAvailableNumbersByHotelIdQuery query)
        {
            var result = await Mediator.Send(query);

            if(result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok(result.Value);
        }
        /// <summary>
        /// Заказать номер
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Заказ, который вы создали</returns>
        [HttpPost]
        public async Task<IActionResult> BookingNumber(BookingNumberCommandDto dto, CancellationToken cancellationToken)
        {
            var command = new BookingNumberCommand { UserId = UserId, DateEnd = dto.DateEnd, DateStart = dto.DateStart, NumberId = dto.NumberId };
            var result = await Mediator.Send(command, cancellationToken);

            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok(result.Value);
        }
        /// <summary>
        /// Оплатить заказ номера
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        [HttpPut]
        public async Task<IActionResult> PayForNumber([FromQuery] PayNumberCommandDto dto, CancellationToken cancellationToken)
        {
            var command = new PayNumberCommand { NumberId = dto.NumberId, UserId = UserId };
            var result = await Mediator.Send(command, cancellationToken);
            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok();
        }
    }
}
