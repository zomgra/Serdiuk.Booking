using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serdiuk.Booking.Application.Hotels.GetAll;
using Serdiuk.Booking.Application.Hotels.GetByFilter;

namespace Serdiuk.Booking.Api.Controllers
{
    /// <summary>
    /// Контроллер для роботы с отелем
    /// </summary>
    [ApiController]
    [Route("api/v1/hotel")]
    public class HotelController : BaseControllerApi
    {
        /// <summary>
        /// Получить все отели за фильтрацией
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetHotelsByFilerAsync([FromQuery]GetHotelsByFilterQuery query, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(query, cancellationToken);
            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok(result.Value);
        }
        /// <summary>
        /// Получить все отели
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllHotels()
        {
            var result = await Mediator.Send(new GetAllHotelQuery());
            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok(result.Value);
        }
    }
}
