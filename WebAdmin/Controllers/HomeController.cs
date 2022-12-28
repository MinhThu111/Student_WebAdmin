using Microsoft.AspNetCore.Mvc;
using Student_WebAdmin.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Student_WebAdmin.Controllers
{
    [Authorize]
    public class HomeController : BaseController<HomeController>
    {
        private readonly IS_Person _s_person;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IS_Person person,ILogger<HomeController> logger)
        {
            _s_person = person;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _s_person.getCountPersonByPersonType(_accessToken);
            ViewBag.data = res.data;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}