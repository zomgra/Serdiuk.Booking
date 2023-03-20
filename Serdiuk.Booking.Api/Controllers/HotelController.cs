using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serdiuk.Booking.Application.Hotels.GetAll;

namespace Serdiuk.Booking.Api.Controllers
{
    /// <summary>
    /// Контроллер для роботы с отелем
    /// </summary>
    [ApiController]
    [Route("api/v1/hotel")]
    public class HotelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HotelController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Получить все отели
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var result = await _mediator.Send(new GetAllHotelQuery());
            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok(result.Value);
        }
    }
}
