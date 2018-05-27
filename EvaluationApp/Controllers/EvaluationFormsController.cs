using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppServices.EmployeeAuthentication;
using AppServices.Evaluations;
using AppServices.EvaluationsForms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationApp.Controllers
{
    public class EvaluationFormsController : Controller
    {
        private readonly IEvaluationFormsService evaluationFormsService;
        private readonly IEvaluationsService evaluationsService;
        private readonly IAuthenticationService authenticationService;
        private readonly IEmployeesService employeesService;

        public EvaluationFormsController(
            IEvaluationFormsService evaluationFormsService,
            IEvaluationsService evaluationsService,
            IAuthenticationService authenticationService,
            IEmployeesService employeesService)
        {
            this.evaluationFormsService = evaluationFormsService;
            this.evaluationsService = evaluationsService;
            this.authenticationService = authenticationService;
            this.employeesService = employeesService;
        }

        public async Task<ActionResult> IndexAsync()
        {
            int loggedEmployeeId = authenticationService.GetCurrentUserId();
            var vm = await evaluationFormsService.GetAllSharedFormsForEmployeeAsync(loggedEmployeeId);

            return View("EvaluationForms", vm);
        }

        public IActionResult FormPreview(int formId)
        {
            var form = evaluationFormsService.GetEvaluationForm(formId);

            if (formId == 0 || (form == null))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("FormPreview", form);
            }
        }
    }
}