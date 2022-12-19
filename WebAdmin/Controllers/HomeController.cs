using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Student_WebAdmin.Models;
using Student_WebAdmin.Services;
using AutoMapper;

namespace Student_WebAdmin.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        private readonly IS_Person _s_person;
        private readonly IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IS_Person person, IMapper mapper, ILogger<HomeController> logger)
        {
            _s_person = person;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _s_person.getCountPersonByPersonType(_accessToken);
            ViewData["data"] = res.data;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}