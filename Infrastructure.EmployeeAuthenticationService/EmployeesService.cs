using IdentityServer.Domain;
using AppServices.EmployeeAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Infrastructure.EmployeeAuthenticationService
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IConfiguration config;
        private HttpClient client = null;

        public EmployeesService(IAuthenticationService authService, IConfiguration configuration)
        {
            authenticationService = authService;
            config = configuration;
            Initialize();
        }
        // MOCKUP METHOD, TO BE IMPLEMENTED
        public Employee GetEmployeeInfo(string userName)
        {
            Employee employee = null;
            try
            {
                var url = "api/GetEmployeeInfo/" + userName;                
                HttpResponseMessage responseMessage = client?.GetAsync(url).Result;

                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    employee = JsonConvert.DeserializeObject<Employee>(result);
                }
            }
            catch (Exception)
            {
               //to do: add logs
            }

            return employee;            
        }

        // MOCKUP METHOD, TO BE IMPLEMENTED
        public ICollection<Employee> GetEmployeesToEvaluate(string userName)
        {
            ICollection<Employee> employees = new List<Employee>();
            
            try
            {
                var url = "api/GetEmployeesToEvaluate/" + userName;               

                HttpResponseMessage responseMessage = client?.GetAsync(url).Result; 
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    var result = responseMessage.Content.ReadAsStringAsync().Result;
                    employees = JsonConvert.DeserializeObject <List <Employee>>(result);
                }
            }
            catch (Exception)
            {
                //to do: add logs
            }  

            return employees;
        }

        private void Initialize()
        {
            var employeesProviderSection = config?.GetSection("EmployeeProvider");
            var employeesProviderUrl = "http://localhost";
            client = new HttpClient();
            employeesProviderUrl = employeesProviderSection?.GetValue<string>("BaseUrl");
            client.BaseAddress = new Uri(employeesProviderUrl);
            
            //return client;
        }
    }
}
