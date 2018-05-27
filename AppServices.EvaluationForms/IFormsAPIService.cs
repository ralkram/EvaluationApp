using EvaluationApp.Domain.FormMockup;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.EvaluationForms
{
    public interface IFormsAPIService
    {
        HttpClient Initialize();
        Task<ICollection<Form>> GetAllSharedFormsForEmployeeAsync(int employeeId);
    }
}
