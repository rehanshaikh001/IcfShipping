using IcfShipping.Models;
using IcfShipping.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IcfShipping.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        //public HomeController(IEmployeeRepository employeeRepository)
        //{
        //    _employeeRepository = employeeRepository;
        //}
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;

        }

        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }

        //public JsonResult Details()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    return Json(model);
        //}

        //public ViewResult Details()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    ViewData["Employee"] = model;
        //    ViewData["PageTitl"] = "Employee Details";
        //    return View();
        //}

        //public ViewResult Details()
        //{
        //    Employee model = _employeeRepository.GetEmployee(1);
        //    ViewBag.PageTitle = "Employee Details";
        //    return View(model);
        //}

        public ViewResult Details()
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(1),
                PageTitle = "Employee Details"
            };
            return View(homeDetailsViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
