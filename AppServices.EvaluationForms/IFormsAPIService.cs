using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppServices.EvaluationForms
{
    public interface IFormsAPIService
    {
        HttpClient Initialize();
    }
}
