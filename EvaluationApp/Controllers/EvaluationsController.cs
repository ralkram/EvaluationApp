using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvaluationApp.Core.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EvaluationApp.Controllers
{
    public class EvaluationsController : Controller
    {
        private readonly IEvaluationFormsService evaluationFormsService;
        private readonly IEvaluationsService evaluationsService;
        private readonly IAuthenticationService authenticationService;

        public EvaluationsController(IEvaluationFormsService evaluationFormsService,
            IEvaluationsService evaluationsService,
            IAuthenticationService authenticationService)
        {
            this.evaluationFormsService = evaluationFormsService;
            this.evaluationsService = evaluationsService;
            this.authenticationService = authenticationService;
        }
    }
}
