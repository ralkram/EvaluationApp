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

namespace Infrastructure.EvaluationFormsService
{
    public class EvaluationFormsService : IEvaluationFormsService
    {
        private readonly IAuthenticationService authenticationService;

        public EvaluationFormsService(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        // MOCKUP METHOD, TO BE IMPLEMENTED
        //public async Task<ICollection<Form>> GetAllSharedFormsForEmployee(int employeeId)
        //{
        //    ICollection<Form> forms = new List<Form>();

        //    forms = await formsAPI.GetAllSharedFormsForEmployee(employeeId);

        //    //ICollection<Criteria> criteria_1 = new List<Criteria>();
        //    //criteria_1.Add(new Criteria { Id = 1, Name = "Naming + proper comments", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
        //    //criteria_1.Add(new Criteria { Id = 2, Name = "Method Cohesion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
        //    //criteria_1.Add(new Criteria { Id = 3, Name = "Class Cohesion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });

        //    //ICollection<Criteria> criteria_2 = new List<Criteria>();
        //    //criteria_2.Add(new Criteria { Id = 4, Name = "Class Coupling", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
        //    //criteria_2.Add(new Criteria { Id = 5, Name = "Open Close Criterion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });

        //    //ICollection<Section> sections = new List<Section>();
        //    //sections.Add(new Section
        //    //{
        //    //    Id = 1,
        //    //    Name = "Software Engineering",
        //    //    Description = "Basic Software Engineering Principles",
        //    //    ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //    //    Criteria = criteria_1
        //    //});

        //    //sections.Add(new Section
        //    //{
        //    //    Id = 2,
        //    //    Name = "Programming",
        //    //    Description = "Basic Programming Principles",
        //    //    ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //    //    Criteria = criteria_2
        //    //});

        //    //forms.Add(new Form
        //    //{
        //    //    Id = 1,
        //    //    Name = "Philadelphia Project",
        //    //    Description = "Form to be used for evaluating skills specific for the Philadelphia Project",
        //    //    Importance = new Importance { Id = 1, Name = "Very important", Level = 5 },
        //    //    Status = true,
        //    //    CreatedDate = new DateTime(2018, 5, 14, 16, 32, 0),
        //    //    ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //    //    Sections = sections
        //    //});

        //    //forms.Add(new Form
        //    //{
        //    //    Id = 2,
        //    //    Name = "Core Technical .NET",
        //    //    Description = "Form for all technicall staff using .NET technologies.",
        //    //    Importance = new Importance { Id = 1, Name = "Very important", Level = 5 },
        //    //    Status = true,
        //    //    CreatedDate = new DateTime(2018, 5, 14, 16, 32, 0),
        //    //    ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //    //    Sections = sections
        //    //});

        //    //forms.Add(new Form
        //    //{
        //    //    Id = 3,
        //    //    Name = "Team Lead Evaluation",
        //    //    Description = "Evaluates team lead specific skills.",
        //    //    Importance = new Importance { Id = 1, Name = "Very important", Level = 5 },
        //    //    Status = false,
        //    //    CreatedDate = new DateTime(2018, 5, 14, 16, 32, 0),
        //    //    ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //    //    Sections = sections
        //    //});

        //    return forms;
        //}

        //public ICollection<Form> GetEnabledSharedFormsForEmployee(int employeeId)
        //{
        //    ICollection<Form> forms = new List<Form>();

        //    ICollection<Criteria> criteria_1 = new List<Criteria>();
        //    criteria_1.Add(new Criteria { Id = 1, Name = "Naming + proper comments", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
        //    criteria_1.Add(new Criteria { Id = 2, Name = "Method Cohesion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
        //    criteria_1.Add(new Criteria { Id = 3, Name = "Class Cohesion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });

        //    ICollection<Criteria> criteria_2 = new List<Criteria>();
        //    criteria_2.Add(new Criteria { Id = 4, Name = "Class Coupling", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
        //    criteria_2.Add(new Criteria { Id = 5, Name = "Open Close Criterion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });

        //    ICollection<Section> sections = new List<Section>();
        //    sections.Add(new Section
        //    {
        //        Id = 1,
        //        Name = "Software Engineering",
        //        Description = "Basic Software Engineering Principles",
        //        ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //        Criteria = criteria_1
        //    });

        //    sections.Add(new Section
        //    {
        //        Id = 2,
        //        Name = "Programming",
        //        Description = "Basic Programming Principles",
        //        ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //        Criteria = criteria_2
        //    });

        //    forms.Add(new Form
        //    {
        //        Id = 1,
        //        Name = "Philadelphia Project",
        //        Description = "Form to be used for evaluating skills specific for the Philadelphia Project",
        //        Importance = new Importance { Id = 1, Name = "Very important", Level = 5 },
        //        Status = new Status { Name = "Enabled" },
        //        CreatedDate = new DateTime(2018, 5, 14, 16, 32, 0),
        //        ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //        Sections = sections
        //    });

        //    forms.Add(new Form
        //    {
        //        Id = 2,
        //        Name = "Core Technical .NET",
        //        Description = "Form for all technicall staff using .NET technologies.",
        //        Importance = new Importance { Id = 1, Name = "Very important", Level = 5 },
        //        Status = new Status { Name = "Enabled" },
        //        CreatedDate = new DateTime(2018, 5, 14, 16, 32, 0),
        //        ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //        Sections = sections
        //    });

        //    return forms;
        //}

        //public Form GetEvaluationForm(int formId)
        //{
        //    ICollection<Form> forms = new List<Form>();
        //    ICollection<EvaluationScaleOption> scaleOptions = new List<EvaluationScaleOption>();

        //    scaleOptions.Add(new EvaluationScaleOption
        //    {
        //        Id = 1,
        //        Name = "Good"
        //    });

        //    scaleOptions.Add(new EvaluationScaleOption
        //    {
        //        Id = 2,
        //        Name = "Very Good"
        //    });

        //    scaleOptions.Add(new EvaluationScaleOption
        //    {
        //        Id = 3,
        //        Name = "Bad"
        //    });

        //    //EvaluationScale evaluationScale = new EvaluationScale
        //    //{
        //    //    Id = 1,
        //    //    Name = "Grades1",
        //    //    EvaluationScaleOptions = scaleOptions
        //    //};

        //    ICollection<Criteria> criteria_1 = new List<Criteria>();
        //    criteria_1.Add(new Criteria { Id = 1, Name = "Naming + proper comments", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
        //    criteria_1.Add(new Criteria { Id = 2, Name = "Method Cohesion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
        //    criteria_1.Add(new Criteria { Id = 3, Name = "Class Cohesion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });

        //    ICollection<Criteria> criteria_2 = new List<Criteria>();
        //    criteria_2.Add(new Criteria { Id = 4, Name = "Class Coupling", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });
        //    criteria_2.Add(new Criteria { Id = 5, Name = "Open Close Criterion", ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0) });

        //    ICollection<Section> sections = new List<Section>();
        //    sections.Add(new Section
        //    {
        //        Id = 1,
        //        Name = "Software Engineering",
        //        Description = "Basic Software Engineering Principles",
        //        ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //        Criteria = criteria_1
        //        // EvaluationScale = evaluationScale
        //    });

        //    sections.Add(new Section
        //    {
        //        Id = 2,
        //        Name = "Programming",
        //        Description = "Basic Programming Principles",
        //        ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //        Criteria = criteria_2
        //        // EvaluationScale = evaluationScale
        //    });

        //    forms.Add(new Form
        //    {
        //        Id = 1,
        //        Name = "Philadelphia Project",
        //        Description = "Form to be used for evaluating skills specific for the Philadelphia Project",
        //        Importance = new Importance { Id = 1, Name = "Very important", Level = 5 },
        //        Status = new Status { Name = "Enabled" },
        //        CreatedDate = new DateTime(2018, 5, 14, 16, 32, 0),
        //        ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //        Sections = sections
        //    });

        //    forms.Add(new Form
        //    {
        //        Id = 2,
        //        Name = "Core Technical .NET",
        //        Description = "Form for all technicall staff using .NET technologies.",
        //        Importance = new Importance { Id = 1, Name = "Very important", Level = 5 },
        //        Status = new Status { Name = "Enabled" },
        //        CreatedDate = new DateTime(2018, 5, 14, 16, 32, 0),
        //        ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //        Sections = sections
        //    });

        //    forms.Add(new Form
        //    {
        //        Id = 3,
        //        Name = "Team Lead Evaluation",
        //        Description = "Evaluates team lead specific skills.",
        //        Importance = new Importance { Id = 1, Name = "Very important", Level = 5 },
        //        Status = new Status { Name = "Enabled" },
        //        CreatedDate = new DateTime(2018, 5, 14, 16, 32, 0),
        //        ModifiedDate = new DateTime(2018, 5, 16, 18, 13, 0),
        //        Sections = sections
        //    });

        //    var form = (from x in forms.OfType<Form>() where x.Id == formId select x).FirstOrDefault();
        //    return form;
        //}

        public async Task<List<SelectListItem>> GetFormNames()
        {
            int empId = authenticationService.GetCurrentUserId();
            var forms = await GetAllFormsForEmployee(empId);
            List<SelectListItem> names = new List<SelectListItem>();
            foreach (var item in forms)
            {
                names.Add(new SelectListItem { Text = item.Name, Value = item.Name });
            }

            return names;
        }

        public async Task<ICollection<EvaluationFormDTO>> GetAllFormsForEmployee(int employeeId)
        {
            ICollection<EvaluationFormDTO> forms = new List<EvaluationFormDTO>();

            var loggedUserId = authenticationService.GetCurrentUserId();

            HttpClient client = Initialize();
            HttpResponseMessage responseMessage = await client.GetAsync("api/forms?userId=" + loggedUserId);

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                forms = JsonConvert.DeserializeObject<List<EvaluationFormDTO>>(result);
            }
            return forms;
        }

        public async Task<EvaluationFormDTO> GetForm(int formId, int userId)
        {
            EvaluationFormDTO form = null;
            var url = "api/forms/" + formId + "?userId=" + userId;
            HttpClient client = Initialize();
            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                form = JsonConvert.DeserializeObject<EvaluationFormDTO>(result);
            }
            return form;
        }

        public HttpClient Initialize()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:63774/");
            return client;
        }
    }
}