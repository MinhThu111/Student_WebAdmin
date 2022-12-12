using Microsoft.AspNetCore.Mvc;

namespace Student_WebAdmin.Controllers
{
    public class AccountController : Controller
    {
        public async Task<IActionResult>Login()
        {
            return View();
        }
        public async Task<IActionResult>Register()
        {
            return View();
        }
    }
}
