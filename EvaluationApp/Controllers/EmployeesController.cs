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
        private readonly IEvaluationFormsService _formService;
        public EmployeesController(IEvaluationFormsService formService)
        {
            _formService = formService;
        }

        public IActionResult Index()
        {
            var vm = _formService.GetEmployees();
            return View("Employees", vm);
        }
    }
}