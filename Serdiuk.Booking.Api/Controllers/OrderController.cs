using Microsoft.AspNetCore.Mvc;
using Serdiuk.Booking.Api.Controllers.Dtos.Order;
using Serdiuk.Booking.Application.Orders.CancelOrder;

namespace Serdiuk.Booking.Api.Controllers
{
    [ApiController]
    [Route("api/v1/hotel/orders")]
    public class OrderController : BaseControllerApi
    {
        [HttpPut]
        public async Task<IActionResult> CancelOrderAsync([FromQuery] CancelOrderCommandDto dto)
        {
            var command = new CancelOrderCommand() { OrderId = dto.OrderId, UserId = UserId};
            var result = await Mediator.Send(command);

            if (result.IsFailed)
                return BadRequest(result.Reasons);
            
            return Ok();
        }
    }
}
