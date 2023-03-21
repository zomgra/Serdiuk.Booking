using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Serdiuk.Booking.Api.Controllers
{
    public class BaseControllerApi : ControllerBase
    {
        private IMediator _mediator;
        public IMediator Mediator =>
            _mediator ?? HttpContext.RequestServices.GetService<IMediator>();

        internal Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        protected IActionResult ConvertToActionResult(ResultBase result)
        {
            if (result.IsFailed)
                return BadRequest(result.Reasons);

            return Ok();
        }
    }
}
