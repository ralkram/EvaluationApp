using AppServices.EvaluationForms;
using EvaluationApp.Domain.FormMockup;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EvaluationFormsService
{
    public class FormsAPIService : IFormsAPIService
    {
        public async Task<ICollection<Form>> GetAllSharedFormsForEmployeeAsync(int employeeId)
        {
            ICollection<Form> forms = new List<Form>();

            HttpClient client = Initialize();
            HttpResponseMessage responseMessage = await client.GetAsync("api/forms?userId=1");

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                forms = JsonConvert.DeserializeObject<List<Form>>(result);
            }
            return forms;
        }

        public HttpClient Initialize()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58549/");
            return client;
        }
    }
}
