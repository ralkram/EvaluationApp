using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvaluationApp.Core.Shared;
using EvaluationApp.Domain;
using EvaluationApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationApp.Controllers
{
    public class EvaluationFormsController : Controller
    {
        private readonly IEvaluationFormsService evaluationformsService;
        private readonly IEvaluationsService evaluationsService;
        private readonly IAuthenticationService authenticationService;
        private readonly IEmployeesService employeesService;

        public EvaluationFormsController(IEvaluationFormsService evaluationformsService,
            IEvaluationsService evaluationsService,
            IAuthenticationService authenticationService,
            IEmployeesService employeesService)
        {
            this.evaluationformsService = evaluationformsService;
            this.evaluationsService = evaluationsService;
            this.authenticationService = authenticationService;
            this.employeesService = employeesService;
        }
        // GET: Forms
        public ActionResult Index()
        {
            int loggedEmployeeId = authenticationService.GetCurrentUserId();
            var vm = evaluationformsService.GetAllSharedFormsForEmployee(loggedEmployeeId);

            return View("EvaluationForms", vm);
        }

        public IActionResult StartEvaluation()
        {
            var vm = new EvaluationViewModel();
            int evaluationFormId = 1;
            var form = evaluationformsService.GetEvaluationForm(evaluationFormId);

            vm.EvaluationName = "Evaluation Test";
            vm.FormName = form.Name;
            vm.Sections = new List<EvaluationApp.Domain.Section>();


            foreach (EvaluationApp.Domain.FormMockup.Section section in form.Sections)
            {
                EvaluationApp.Domain.Section evaluationSection = new EvaluationApp.Domain.Section();
                ICollection<EvaluationApp.Domain.Criteria> sectionCriteria = new List<EvaluationApp.Domain.Criteria>();


                foreach (EvaluationApp.Domain.FormMockup.Criteria criteria in section.Criteria)
                {
                    EvaluationApp.Domain.Criteria EvaluationCriteria = new EvaluationApp.Domain.Criteria
                    {
                        Id = criteria.Id,
                        Name = criteria.Name,
                        ModifiedDate = criteria.ModifiedDate,
                        CreatedBy = criteria.CreatedBy,
                        ModifiedBy = criteria.ModifiedBy
                    };

                    sectionCriteria.Add(EvaluationCriteria);
                }
                evaluationSection.Id = section.Id;
                evaluationSection.Name = section.Name;
                evaluationSection.Description = section.Description;
                evaluationSection.Criteria = sectionCriteria;
                // evaluationSection.EvaluationScale = section.EvaluationScale;
                evaluationSection.ModifiedDate = section.ModifiedDate;
                evaluationSection.CreatedBy = section.CreatedBy;
                evaluationSection.ModifiedBy = section.ModifiedBy;
                vm.Sections.Add(evaluationSection);
            }

            return View("StartEvaluation", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult StartEvaluation(EvaluationViewModel evaluation)
        {
            if (ModelState.IsValid)
            {
                var eval = new Evaluation
                {
                    Sections = evaluation.Sections
                };

                evaluationsService.StartEvaluation(eval);
                return RedirectToAction(nameof(Index));
            }

            return View("StartEvaluation", evaluation);
        }

        // GET: Forms/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Forms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Forms/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Forms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Forms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Forms/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}