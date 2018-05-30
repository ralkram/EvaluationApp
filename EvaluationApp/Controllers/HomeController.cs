using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EvaluationApp.Models;
using AppServices.EmployeeAuthentication;

namespace EvaluationApp.Controllers
{
    public class HomeController : Controller
    {
        private IAuthenticationService authenticationService;

        public HomeController(IAuthenticationService auth)
        {
            authenticationService = auth;
        }
        public IActionResult Index()
        {
            return View();            
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignOut()
        {
            authenticationService.SignOut();
            return View("Index");
        }
    }
}
