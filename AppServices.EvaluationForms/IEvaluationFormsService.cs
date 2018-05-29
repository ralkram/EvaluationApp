using EvaluationFormsManager.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppServices.EvaluationsForms
{
    public interface IEvaluationFormsService
    {
        //Task<ICollection<Form>> GetAllSharedFormsForEmployee(int employeeId);
        //ICollection<Form> GetEnabledSharedFormsForEmployee(int employeeId);
        //Form GetEvaluationForm(int formId);

        Task<List<SelectListItem>> GetFormNames();
        HttpClient Initialize();
        Task<ICollection<EvaluationFormDTO>> GetAllFormsForEmployee(int employeeId);
        Task<EvaluationFormDTO> GetForm(int formId, int userId);
    }
}
