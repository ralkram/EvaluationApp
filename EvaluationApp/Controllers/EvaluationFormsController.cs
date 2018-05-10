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
        private readonly IEvaluationFormsService _formService;
        public EvaluationFormsController(IEvaluationFormsService formService)
        {
            _formService = formService;
        }
        // GET: Forms
        public ActionResult Index()
        {
            var vm = _formService.GetForms(1);

            return View("EvaluationForms", vm);
        }

        public IActionResult StartEvaluation()
        {
            var vm = new EvaluationViewModel();
            var eval = _formService.GetEvaluationForm();

            vm.EvaluationName = eval.EvaluationName;
            vm.FormName = eval.FormName;
            vm.Sections = eval.Sections;
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
                    FormName = evaluation.FormName,
                    EvaluationName = evaluation.EvaluationName,
                    Sections = evaluation.Sections
                };

                _formService.StartEvaluation(eval);
                return RedirectToAction(nameof(Index));
            }            

            return View("StartEvaluation", evaluation);
        }

        public IActionResult InProgress()
        {
            var vm = _formService.GetInProgressEvaluations();

            return View(vm);
        }

        public IActionResult Completed()
        {
            var vm = _formService.GetCompletedEvaluations();

            return View(vm);
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