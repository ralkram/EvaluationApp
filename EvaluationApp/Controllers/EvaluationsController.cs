using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvaluationApp.Core.Shared;
using EvaluationApp.Domain;
using EvaluationApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [HttpGet]
        public IActionResult DeleteModal(int id)
        {
            Evaluation evaluation= evaluationsService.GetEvaluationById(id);
            EvaluationViewModel evaluationViewModel = GenerateEvaluationViewModel(evaluation);

            return View("DeleteModal", evaluationViewModel);
        }

        //[HttpPost("{evaluationId}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DoDelete(int evaluationId)
        {
            return RedirectToAction(nameof(Completed));
        }

        public IActionResult InProgress()
        {
            int loggedEmployeeId = authenticationService.GetCurrentUserId();
            var inProgressEvaluations = evaluationsService.GetInProgressEvaluationsForEvaluator(loggedEmployeeId);
            var evaluationViewModels = GenerateEvaluationViewModels(inProgressEvaluations);

            return View(evaluationViewModels);
        }
        public IActionResult Completed()
        {
            int loggedEmployeeId = authenticationService.GetCurrentUserId();
            var completedEvaluations = evaluationsService.GetCompletedEvaluationsForEvaluator(loggedEmployeeId);
            var evaluationViewModels = GenerateEvaluationViewModels(completedEvaluations);

            return View(evaluationViewModels);
        }

        [HttpGet]
        public IActionResult StartFormEvaluationModal(int id)
        {

            int currentEmployeeId = authenticationService.GetCurrentUserId();

            var vm = new StartEvaluationViewModel();
            vm.SelectedForm = id;
            vm.IsFormEnabled = false;
            vm.Name = "";

            vm.EmployeesList = employeesService.GetEmployeesToEvaluate(currentEmployeeId)
                            .Select(employee => 
                                    new SelectListItem { Text = employee.Name, Value = "" + employee.Id })
                            .ToList();
            vm.FormsList = evaluationFormsService.GetEnabledSharedFormsForEmployee(currentEmployeeId)
                           .Select(form => 
                                   new SelectListItem { Text = form.Name, Value = "" + form.Id, Selected = (form.Id == id) })
                                   .ToList();
            vm.IsEmployeeEnabled = true;
                                
              
            return View("StartEvaluationModal", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StartFormEvaluationModal(StartEvaluationViewModel evaluation)
        {
            if (ModelState.IsValid)
            {
                var form = evaluationFormsService.GetEvaluationForm(evaluation.SelectedForm);
                var eval = new Evaluation
                {
                    EvaluationName = evaluation.Name,
                    FormName = form.Name,
                    EmployeeId = evaluation.SelectedEmployee                   
                };
                evaluationsService.StartEvaluation(eval);
                return RedirectToAction("StartEvaluation", new { id = eval.Id, formName = form.Name, evaluationName = evaluation.Name });
                //return View("StartEvaluation", evaluation);
            }
            return RedirectToAction(nameof(InProgress));
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
                var eval = new Evaluation
                {
                    EvaluationName = evaluation.EvaluationName,
                    FormName = evaluation.FormName
                };
                evaluationsService.StartEvaluation(eval);
                return RedirectToAction("StartEvaluation", new { id = eval.Id, formName = evaluation.FormName, evaluationName = evaluation.EvaluationName });
                //return View("StartEvaluation", evaluation);
            }
            return RedirectToAction(nameof(InProgress));
        }

        [HttpGet]
       // [Route("Evaluations/StartEvaluation/{activityId}", Name = "StartEvaluation")]
        public IActionResult StartEvaluation(int id, string formName, string evaluationName)
        {
            var evaluation = new EvaluationViewModel();
            var sections = evaluationFormsService.GetEvaluationForm(1).Sections;
            evaluation.Sections = evaluationsService.MapFormSectionsToEvaluationSections(sections);
            evaluation.Id = id;
            evaluation.EvaluationName = evaluationName;
            evaluation.FormName = formName;

            return View("StartEvaluation", evaluation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Evaluations/UpdateEvaluation", Name = "UpdateEvaluation")]
        public IActionResult UpdateEvaluation(EvaluationData evaluation)
        {
            if (ModelState.IsValid)
            {
                var oldEvaluation = evaluationsService.GetEvaluationById(evaluation.Id);
                if (oldEvaluation != null)
                {
                    foreach (var criteriaData in evaluation.CriteriaData)
                    {
                        var criteriaSection = oldEvaluation.Sections
                                                               .Where(section => section.Id ==  criteriaData.SectionId)
                                                               .FirstOrDefault();
                        if (criteriaSection != null)
                        {
                            var oldCriteria = criteriaSection.Criteria
                                                             .Where(criteria => criteria.Id == criteriaData.Id)
                                                             .FirstOrDefault();
                            if (oldCriteria != null)
                            {
                                if (criteriaData.GradeId != 0)
                                { 
                                    oldCriteria.Grade = evaluationFormsServic
                                }
                            }
                        }
                    }
                    evaluationsService.UpdateEvaluation(oldEvaluation, evaluation.Id);
                }                
                return RedirectToAction(nameof(InProgress));
            }

            return View("StartEvaluation", evaluation);
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
                LastEvaluator = employeesService.GetEmployeeInfo(evaluation.LastEvaluatorId),
                CreatedDate = evaluation.CreatedDate,
                ModifiedDate = evaluation.ModifiedDate
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
