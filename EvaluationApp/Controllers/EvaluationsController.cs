using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvaluationApp.Core.Shared;
using EvaluationApp.Domain;
using EvaluationApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationApp.Controllers
{
    public class EvaluationsController : Controller
    {
        private readonly IEvaluationFormsService evaluationFormsService;
        private readonly IEvaluationsService evaluationsService;
        private readonly IAuthenticationService authenticationService;
        private readonly IEmployeesService employeesService;

        public EvaluationsController(
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

        public IActionResult InProgress()
        {
            int loggedEmployeeId = authenticationService.GetCurrentUserId();
            var inProgressEvaluations = evaluationsService.GetInProgressEvaluations(loggedEmployeeId);
            var evaluationViewModels = GenerateEvaluationViewModels(inProgressEvaluations);

            return View(evaluationViewModels);
        }
        public IActionResult Completed()
        {
            int loggedEmployeeId = authenticationService.GetCurrentUserId();
            var completedEvaluations = evaluationsService.GetCompletedEvaluations(loggedEmployeeId);
            var evaluationViewModels = GenerateEvaluationViewModels(completedEvaluations);

            return View(evaluationViewModels);
        }
        [HttpGet]
        public IActionResult StartEvaluationModal()
        {
            var vm = new EvaluationViewModel();
            vm.Forms = evaluationFormsService.GetFormNames();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StartEvaluationModal(EvaluationViewModel evaluation)
        {
            if (ModelState.IsValid)
            {
                var sections = evaluationFormsService.GetEvaluationForm(1).Sections;
                evaluation.Sections = evaluationsService.MapFormSectionsToEvaluationSections(sections);
                
                var eval = new Evaluation
                {
                    EvaluationName = evaluation.EvaluationName,
                    FormName = evaluation.FormName
                };
                evaluationsService.StartEvaluation(eval);
                return View("StartEvaluation", evaluation);
            }
            return RedirectToAction(nameof(InProgress));
        }

        private EvaluationViewModel GenerateEvaluationViewModel(Evaluation evaluation)
        {
            EvaluationViewModel evaluationViewModel = new EvaluationViewModel
            {
                Id = evaluation.Id,
                EvaluationName = evaluation.EvaluationName,
                FormName = evaluation.FormName,
                IsCompleted = evaluation.IsCompleted,
                //Sections = evaluation.Sections,
                Employee = employeesService.GetEmployeeInfo(evaluation.EmployeeId),
                LastEvaluator = employeesService.GetEmployeeInfo(evaluation.LastEvaluatorId)
            };
            return evaluationViewModel;
        }

        private ICollection<EvaluationViewModel> GenerateEvaluationViewModels(ICollection<Evaluation> evaluations)
        {
            ICollection<EvaluationViewModel> evaluationViewModels = new List<EvaluationViewModel>();

            foreach (var evaluation in evaluations)
            {
                evaluationViewModels.Add(GenerateEvaluationViewModel(evaluation));
            }
            return evaluationViewModels;
        }

        public IActionResult Details(int evaluationId)
        {
            var evaluation = evaluationsService.GetEvaluationById(evaluationId);

            if (evaluationId == 0 || (evaluation == null))
            {
                return RedirectToAction("Completed");
            }
            else
            {
                var evaluationViewModel = GenerateEvaluationViewModel(evaluation);
                return View(evaluationViewModel);
            }
        }
    }
}
