using AppServices.EvaluationForms;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Infrastructure.EvaluationFormsService
{
    public class FormsAPIService : IFormsAPIService
    {
        public HttpClient Initialize()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:58549/");
            return client;
        }
    }
}
