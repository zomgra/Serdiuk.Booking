using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serdiuk.Booking.Api.Controllers.Dtos.Order;
using Serdiuk.Booking.Application.Numbers.BookNumber;
using Serdiuk.Booking.Application.Orders.CancelOrder;
using Serdiuk.Booking.Application.Orders.GetOrdersByUserId;

namespace Serdiuk.Booking.Api.Controllers
{
    [ApiController]
    [Route("api/v1/hotel/orders")]
    [Authorize]
    public class OrderController : BaseControllerApi
    {
        [HttpGet]
        public async Task<IActionResult> GetOrdersByUserId()
        {
            var query = new GetOrdersByUserIdQuery() { UserId = UserId };
            var result = await Mediator.Send(query);

            if (result.IsFailed)
                return BadRequest(result.Reasons);
            return Ok(result.Value);
        }
        /// <summary>
        /// Отменить заказ
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> CancelOrderAsync(CancelOrderCommandDto dto)
        {
            var command = new CancelOrderCommand() { OrderId = dto.OrderId, UserId = UserId};
            var result = await Mediator.Send(command);

            if (result.IsFailed)
                return BadRequest(result.Reasons);
            
            return Ok();
        }
        /// <summary>
        /// Оплатить заказ номера
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="cancellationToken"></param>
        [HttpPut("pay")]
        public async Task<IActionResult> PayForOrder(PayNumberCommandDto dto, CancellationToken cancellationToken)
        {
            var command = new PayNumberCommand { OrderId = dto.OrderId, UserId = UserId };
            var result = await Mediator.Send(command, cancellationToken);
            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok();
        }
    }
}
