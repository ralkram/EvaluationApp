﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvaluationApp.Core.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EvaluationApp.Controllers
{
    public class EvaluationController : Controller
    {
        private readonly IEvaluationFormsService evaluationFormsService;

        public EvaluationController(IEvaluationFormsService evaluationFormsService)
        {
            this.evaluationFormsService = evaluationFormsService;
        }
    }
}
