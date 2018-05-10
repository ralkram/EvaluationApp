using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvaluationApp.Core.Shared;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService employeeService;
        private readonly IAuthenticationService authenticationService;

        public EmployeesController(IEmployeesService employeeService, IAuthenticationService authenticationService)
        {
            this.employeeService = employeeService;
            this.authenticationService = authenticationService;
        }

        public IActionResult Index()
        {
            int loggedEmployeeId = authenticationService.GetCurrentUserId();
            var vm = employeeService.GetEmployeesToEvaluate(loggedEmployeeId);

            return View("Employees", vm);
        }
    }
}