using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Newtonsoft.Json;

namespace EvaluationApp.Controllers
{
    
    public class EvaluationsController : Controller
    {
        private readonly IEvaluationFormsService evaluationFormsService;
        private readonly IEvaluationsService evaluationsService;
        private readonly IAuthenticationService authenticationService;
        private readonly IEmployeesService employeesService;
        private readonly IEvaluationStatisticsService statisticsService;

        public EvaluationsController(
            IEvaluationFormsService evaluationFormsService,
            IEvaluationsService evaluationsService,
            IAuthenticationService authenticationService,
            IEmployeesService employeesService,
            IEvaluationStatisticsService statisticsService
            )
        {
            this.evaluationFormsService = evaluationFormsService;
            this.evaluationsService = evaluationsService;
            this.authenticationService = authenticationService;
            this.employeesService = employeesService;
            this.statisticsService = statisticsService;
        }

        [HttpGet]
        public IActionResult DeleteModal(int id)
        {
            Evaluation evaluation = evaluationsService.GetEvaluationById(id);
            EvaluationViewModel evaluationViewModel = GenerateEvaluationViewModel(evaluation);

            return View("DeleteModal", evaluationViewModel);
        }

        //[HttpPost("{evaluationId}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DoDelete(int id)
        {
            evaluationsService.Delete(id);
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
        public async Task<IActionResult> StartFormEvaluationModal(int id)
        {
            int currentEmployeeId = authenticationService.GetCurrentUserId();
            var forms = await evaluationFormsService.GetAllFormsForEmployee(currentEmployeeId);

            var vm = new StartEvaluationViewModel();
            vm.SelectedForm = id;
            vm.IsFormEnabled = false;
            vm.Name = "";

            vm.EmployeesList = employeesService.GetEmployeesToEvaluate(currentEmployeeId)
                            .Select(employee => 
                                    new SelectListItem { Text = employee.Name, Value = "" + employee.Id })
                            .ToList();
            //vm.FormsList = evaluationFormsService.GetEnabledSharedFormsForEmployee(currentEmployeeId)
            //               .Select(form => 
            //                       new SelectListItem { Text = form.Name, Value = "" + form.Id, Selected = (form.Id == id) })
            //                       .ToList();
            
            vm.FormsList = forms.Select(form =>
                                   new SelectListItem { Text = form.Name, Value = "" + form.Id, Selected = (form.Id == id) })
                                   .ToList();
            vm.IsEmployeeEnabled = true;
                                
              
            return View("StartEvaluationModal", vm);
        }

        [HttpPost]
        public async Task<IActionResult> StartFormEvaluationModal(StartEvaluationViewModel evaluation)
        {
            //var form = evaluationFormsService.GetEvaluationForm(evaluation.SelectedForm);
            int currentEmployeeId = authenticationService.GetCurrentUserId();
            var form = await evaluationFormsService.GetForm(evaluation.SelectedForm, currentEmployeeId);

            var eval = new Evaluation
            {
                EvaluationName = evaluation.Name,
                FormName = form.Name,
                FormId = form.Id,
                EmployeeId = evaluation.SelectedEmployee,
                Sections = evaluationsService.MapFormSectionsToEvaluationSections(form.Sections),
                CreatedBy = currentEmployeeId,
                LastEvaluatorId = currentEmployeeId,
                ModifiedBy = currentEmployeeId,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            evaluationsService.InsertEvaluation(eval);

            return RedirectToAction("Evaluate", new { id = eval.Id });
        }

        [HttpGet]
        public IActionResult Evaluate(int id)
        {
            var eval = evaluationsService.GetEvaluationById(id);
            EvaluationFormViewModel formVM = new EvaluationFormViewModel();
            formVM.Id = eval.Id;
            formVM.Sections = eval.Sections;
            formVM.FormName = eval.FormName;
            formVM.EvaluationName = eval.EvaluationName;
            formVM.EmployeeName = employeesService.GetEmployeeInfo(eval.EmployeeId).Name;
            formVM.IsCompleted = eval.IsCompleted;
            formVM.SectionScales = new Dictionary<int, SectionScaleViewModel>();
            //NOTE: each section has its own scale

            foreach (var section in eval.Sections)
            {
                var sectionScale = section.EvaluationScale;
                if (sectionScale != null)
                {
                    var scaleOptions = evaluationsService.GetEvaluationScaleOptionsFromScale(sectionScale.Id);
                    var scaleOptionsVM = new SectionScaleViewModel() { SectionId = section.Id};
                    var options = new List<SelectListItem>();                  
                    options.Add(new SelectListItem (){ Value = "0", Text = "Not Evaluated" });                  
                        
                   options.AddRange(scaleOptions.Select(option => 
                                                    new SelectListItem
                                                    {
                                                        Value = "" + option.Id,
                                                        Text = option.Name
                                                    })
                                                     .ToList());
                    scaleOptionsVM.ScaleOptions = options;

                    formVM.SectionScales[section.Id] = scaleOptionsVM;
                }
                
            }         

            return View("EvaluationForm", formVM);
        }

        //public ContentResult JSON()
        //{
        //    List<DataPoint> dataPoints = new List<DataPoint>();

        //    var statistics = statisticsService.GetStatisticsForFormAndEmployee(1, 1);

        //    int i = 0;

        //    foreach (var evaluation in statistics.ProgressEvaluations)
        //    {
        //        foreach (var section in evaluation.ProgressSections)
        //        {
        //            dataPoints.Add(new DataPoint(i++, section.SectionAverageGrade.Value));
        //        }
        //    }

        //    JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        //    return Content(JsonConvert.SerializeObject(dataPoints, _jsonSetting), "application/json");
        //}

        [HttpPost]        
        [Route("Evaluations/UpdateEvaluation", Name = "UpdateEvaluation")]
        public IActionResult UpdateEvaluation([FromBody]EvaluationData evaluationData)
        {
            ResponseData responseData = new ResponseData { Status = Ok().StatusCode, IsError = false, Text = "Evaluation saved successfully" };
            if (ModelState.IsValid)
            {
                try
                {
                    evaluationsService.UpdateEvaluationData(evaluationData);
                }
                catch (Exception e)
                {
                    responseData = new ResponseData { Status = (int)HttpStatusCode.NotModified, IsError = true, Text = "Failed to save evaluation." };
                }
                return Ok(responseData);               
            }

            return BadRequest();
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

        public IActionResult DetailsCompleted(int evaluationId)
        {
            var evaluation = evaluationsService.GetEvaluationById(evaluationId);

            var test = statisticsService.GetStatisticsForFormAndEmployee(1, 2);

            if (evaluationId == 0 || (evaluation == null))
            {
                return RedirectToAction("Completed");
            }
            else
            {
                var evaluationViewModel = GenerateEvaluationViewModel(evaluation);
                return View("EvaluationDetails/DetailsCompleted", evaluationViewModel);
            }
        }

        public IActionResult DetailsInProgress(int evaluationId)
        {
            var evaluation = evaluationsService.GetEvaluationById(evaluationId);

            if (evaluationId == 0 || (evaluation == null))
            {
                return RedirectToAction("InProgress");
            }
            else
            {
                var evaluationViewModel = GenerateEvaluationViewModel(evaluation);
                return View("EvaluationDetails/DetailsInProgress", evaluationViewModel);
            }
        }
    }
}
