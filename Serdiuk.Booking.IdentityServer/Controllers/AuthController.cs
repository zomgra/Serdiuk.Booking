using Microsoft.AspNetCore.Mvc;
using Serdiuk.Booking.IdentityServer.Models;

namespace Serdiuk.Booking.IdentityServer.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {

            return View(model);
        }
        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            return View(new RegisterViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            return View(model);
        }
    }
}
