using EvaluationApp.Domain.FormMockup;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppServices.EvaluationsForms
{
    public interface IEvaluationFormsService
    {
        Task<ICollection<Form>> GetAllSharedFormsForEmployee(int employeeId);
        ICollection<Form> GetEnabledSharedFormsForEmployee(int employeeId);

        Form GetEvaluationForm(int formId);
        Task<List<SelectListItem>> GetFormNames();
    }
}
