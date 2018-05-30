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

        [Authorize]
        public IActionResult Index()
        {
            int loggedEmployeeId = authenticationService.GetCurrentUserId();
            var vm = employeesService.GetEmployeesToEvaluate(loggedEmployeeId);

            return View("Employees", vm);
        }

        [HttpGet]
        public async Task<IActionResult> StartFormEvaluationModal(int id)
        {
            int loggedEmployeeId = authenticationService.GetCurrentUserId();
            var forms = await evaluationFormsService.GetAllFormsForEmployee(loggedEmployeeId);

            var vm = new StartEvaluationViewModel();
            vm.SelectedEmployee = id;
            vm.IsEmployeeEnabled = false;
            vm.Name = "";

            vm.EmployeesList = employeesService.GetEmployeesToEvaluate(loggedEmployeeId)
                            .Select(employee =>
                                    new SelectListItem { Text = employee.Name, Value = "" + employee.Id, Selected = (employee.Id == id) })
                            .ToList();
            vm.FormsList = forms.Select(form =>
                                   new SelectListItem { Text = form.Name, Value = "" + form.Id, Selected = (form.Id == id) })
                                   .ToList();
            vm.IsFormEnabled = true;


            return View("StartEvaluationModal", vm);
        }

        [HttpGet]
        public async Task<IActionResult> ViewEmployeeProgressModal(int id)
        {
            int loggedEmployeeId = authenticationService.GetCurrentUserId();
            var forms = await evaluationFormsService.GetAllFormsForEmployee(loggedEmployeeId);

            var vm = new EmployeeProgressViewModel();
            vm.SelectedEmployee = id;
            vm.IsEmployeeEnabled = false;

            vm.EmployeesList = employeesService.GetEmployeesToEvaluate(loggedEmployeeId)
                            .Select(employee =>
                                    new SelectListItem { Text = employee.Name, Value = "" + employee.Id, Selected = (employee.Id == id) })
                            .ToList();
            vm.FormsList = forms.Select(form =>
                                   new SelectListItem { Text = form.Name, Value = "" + form.Id, Selected = (form.Id == id) })
                                   .ToList();
            vm.IsFormEnabled = true;


            return View("ViewEmployeeProgressModal", vm);
        }

        [HttpGet]
        public IActionResult EmployeeProgress(EmployeeProgressViewModel vm)
        {
            int loggedEmployeeId = authenticationService.GetCurrentUserId();
            var form = evaluationFormsService.GetForm(vm.SelectedForm, loggedEmployeeId);

            var EvaluationFormStatistics = evaluationStatistics.GetStatisticsForFormAndEmployee(vm.SelectedForm, vm.SelectedEmployee);
            return View(EvaluationFormStatistics);
        }

        public IActionResult InProgress(int employeeId)
        {
            var inProgressEvaluations = evaluationsService.GetInProgressEvaluationsForEmployee(employeeId);
            var evaluationViewModels = GenerateEvaluationViewModels(inProgressEvaluations);

            return View(evaluationViewModels);
        }
        public IActionResult Completed(int employeeId)
        {
            var completedEvaluations = evaluationsService.GetCompletedEvaluationsForEmployee(employeeId);
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