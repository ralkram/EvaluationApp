using EvaluationApp.Domain.FormMockup;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace EvaluationApp.AppServices.EvaluationsForms
{
    public interface IEvaluationFormsService
    {
        ICollection<Form> GetAllSharedFormsForEmployee(int employeeId);
        ICollection<Form> GetEnabledSharedFormsForEmployee(int employeeId);

        Form GetEvaluationForm(int formId);
        List<SelectListItem> GetFormNames();
        //List<SelectListItem> GetEvaluationGrades(Domain.Section section);
    }
}
