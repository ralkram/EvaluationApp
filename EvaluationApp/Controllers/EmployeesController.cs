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
        private readonly IEvaluationFormService _formService;
        public EmployeesController(IEvaluationFormService formService)
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