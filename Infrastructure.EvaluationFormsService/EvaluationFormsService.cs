using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppServices.EmployeeAuthentication;
using AppServices.EvaluationsForms;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EvaluationFormsManager.DataTransferObjects;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EvaluationFormsService
{
    public class EvaluationFormsService : IEvaluationFormsService
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IConfiguration config;
        private HttpClient client = null;
       
        public EvaluationFormsService(IAuthenticationService authenticationService, IConfiguration config)
        {
            this.authenticationService = authenticationService;
            this.config = config;
            Initialize();
        }

        public async Task<List<SelectListItem>> GetFormNames()
        {
            string loggedUserName = authenticationService.GetCurrentUserId();
            var forms = await GetAllFormsForEmployee(loggedUserName);
            List<SelectListItem> names = new List<SelectListItem>();
            foreach (var item in forms)
            {
                names.Add(new SelectListItem { Text = item.Name, Value = item.Name });
            }

            return names;
        }
        public async Task<ICollection<EvaluationFormDTO>> GetAllFormsForEmployee(string userName)
        {
            ICollection<EvaluationFormDTO> forms = new List<EvaluationFormDTO>();

            try
            {
                var loggedUserName = authenticationService.GetCurrentUserId();

               // HttpClient client = Initialize();
                HttpResponseMessage responseMessage = await client.GetAsync("api/forms/owned?userId=" + loggedUserName);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    forms = JsonConvert.DeserializeObject<List<EvaluationFormDTO>>(result);
                }
            }
            catch (HttpRequestException e)
            {
                return forms;
            }

            
            return forms;
        }

        public async Task<EvaluationFormDTO> GetForm(int formId, string userName)
        {
            EvaluationFormDTO form = null;

            try
            {
                var url = "api/forms/" + formId + "?userId=" + userName;
                //HttpClient client = Initialize();
                HttpResponseMessage responseMessage = await client.GetAsync(url);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    form = JsonConvert.DeserializeObject<EvaluationFormDTO>(result);
                }
            }
            catch (HttpRequestException e)
            {
                return null;
            }
            return form;
        }

        public void Initialize()
        {
            var formsProviderSection = config.GetSection("FormsProvider");
            var formsProviderUrl = "http://localhost";
            client = new HttpClient();
            formsProviderUrl = formsProviderSection?.GetValue<string>("BaseUrl");
            client.BaseAddress = new Uri(formsProviderUrl);
            //return client;
        }
    }
}