using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppServices.EmployeeAuthentication;
using AppServices.Evaluations;
using AppServices.EvaluationsForms;
using AppServices.EvaluationStatistics;
using DomainModel.Domain;
using EvaluationApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EvaluationApp.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEvaluationFormsService evaluationFormsService;
        private readonly IEvaluationsService evaluationsService;
        private readonly IAuthenticationService authenticationService;
        private readonly IEmployeesService employeesService;
        private readonly IEvaluationStatisticsService evaluationStatistics;

        public EmployeesController(
            IEmployeesService employeeService,
            IEvaluationFormsService evaluationFormsService,
            IEvaluationsService evaluationsService,
            IAuthenticationService authenticationService,
            IEvaluationStatisticsService evaluationStatistics)
        {
            this.evaluationFormsService = evaluationFormsService;
            this.evaluationsService = evaluationsService;
            this.employeesService = employeeService;
            this.authenticationService = authenticationService;
            this.evaluationStatistics = evaluationStatistics;
        }

        public IActionResult Index()
        {
            string loggedUserName = authenticationService.GetCurrentUserId();
            var vm = employeesService.GetEmployeesToEvaluate(loggedUserName);

            return View("Employees", vm);
        }

        [HttpGet]
        public async Task<IActionResult> StartFormEvaluationModal(string id)
        {
            string loggedUserName = authenticationService.GetCurrentUserId();
            var forms = await evaluationFormsService.GetAllFormsForEmployee(loggedUserName);

            var vm = new StartEvaluationViewModel();
            vm.SelectedEmployee = id;
            vm.IsEmployeeEnabled = false;
            vm.Name = "";

            vm.EmployeesList = employeesService.GetEmployeesToEvaluate(loggedUserName)
                            .Select(employee =>
                                    new SelectListItem { Text = employee.Name, Value = "" + employee.Username, Selected = (employee.Username == id) })
                            .ToList();
            vm.FormsList = forms.Select(form =>
                                   new SelectListItem { Text = form.Name, Value = "" + form.Id})
                                   .ToList();
            vm.IsFormEnabled = true;


            return View("StartEvaluationModal", vm);
        }

        [HttpGet]
        public async Task<IActionResult> ViewEmployeeProgressModal(string id)
        {
            string loggedUserName = authenticationService.GetCurrentUserId();
            var forms = await evaluationFormsService.GetAllFormsForEmployee(loggedUserName);

            var vm = new EmployeeProgressViewModel();
            vm.SelectedEmployee = id;
            vm.IsEmployeeEnabled = false;

            vm.EmployeesList = employeesService.GetEmployeesToEvaluate(loggedUserName)
                            .Select(employee =>
                                    new SelectListItem { Text = employee.Name, Value = "" + employee.Username, Selected = (employee.Username == id) })
                            .ToList();
            vm.FormsList = forms.Select(form =>
                                   new SelectListItem { Text = form.Name, Value = "" + form.Id })
                                   .ToList();
            vm.IsFormEnabled = true;

            return View("ViewEmployeeProgressModal", vm);
        }

        [HttpGet]
        public IActionResult EmployeeProgress(EmployeeProgressViewModel vm)
        {
            string loggedUserName = authenticationService.GetCurrentUserId();
            var form = evaluationFormsService.GetForm(vm.SelectedForm, loggedUserName);

            var EvaluationFormStatistics = evaluationStatistics.GetStatisticsForFormAndEmployee(vm.SelectedForm, vm.SelectedEmployee);
            return View(EvaluationFormStatistics);
        }

        public IActionResult InProgress(string employeeUserName)
        {
            var inProgressEvaluations = evaluationsService.GetInProgressEvaluationsForEmployee(employeeUserName);
            var evaluationViewModels = GenerateEvaluationViewModels(inProgressEvaluations);

            return View(evaluationViewModels);
        }
        public IActionResult Completed(string employeeUserName)
        {
            var completedEvaluations = evaluationsService.GetCompletedEvaluationsForEmployee(employeeUserName);
            var evaluationViewModels = GenerateEvaluationViewModels(completedEvaluations);

            return View(evaluationViewModels);
        }

        private EvaluationViewModel GenerateEvaluationViewModel(Evaluation evaluation)
        {
            EvaluationViewModel evaluationViewModel = new EvaluationViewModel
            {
                Id = evaluation.Id,
                EvaluationName = evaluation.EvaluationName,
                FormName = evaluation.FormName,
                IsCompleted = evaluation.IsCompleted,
                Sections = evaluation.Sections,
                Employee = employeesService.GetEmployeeInfo(evaluation.EmployeeId),
                LastEvaluator = employeesService.GetEmployeeInfo(evaluation.LastEvaluatorId),
                CreatedDate = evaluation.CreatedDate,
                ModifiedDate = evaluation.ModifiedDate
            };

            return evaluationViewModel;
        }

        private IEnumerable<EvaluationViewModel> GenerateEvaluationViewModels(IEnumerable<Evaluation> evaluations)
        {
            ICollection<EvaluationViewModel> evaluationViewModels = new List<EvaluationViewModel>();

            foreach (var evaluation in evaluations)
            {
                evaluationViewModels.Add(GenerateEvaluationViewModel(evaluation));
            }

            IEnumerable<EvaluationViewModel> evaluationViewModelsEnumerable = new List<EvaluationViewModel>(evaluationViewModels);

            return evaluationViewModelsEnumerable;
        }

    }
}