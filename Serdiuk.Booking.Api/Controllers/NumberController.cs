using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serdiuk.Booking.Application.Numbers.BookingNumber;
using Serdiuk.Booking.Application.Numbers.BookNumber;
using Serdiuk.Booking.Application.Numbers.GetAvailableByHotelId;

namespace Serdiuk.Booking.Api.Controllers
{
    /// <summary>
    /// Контроллер по работе с номерами отеля
    /// </summary>
    [ApiController]
    [Route("api/v1/hotel/numbers")]
    public class NumberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NumberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получить все доступные отели по идентификатору отеля
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAvailableNumberByHotelId([FromQuery] GetAvailableNumbersByHotelIdQuery query)
        {
            var result = await _mediator.Send(query);
            if(result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok(result.Value);
        }
        /// <summary>
        /// Заказать номер
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Заказ, который вы создали</returns>
        [HttpPost]
        public async Task<IActionResult> BookingNumber(BookingNumberCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok(result.Value);
        }
        [HttpPut]
        public async Task<IActionResult> PayForNumber([FromQuery] PayNumberCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok();
        }
    }
}
