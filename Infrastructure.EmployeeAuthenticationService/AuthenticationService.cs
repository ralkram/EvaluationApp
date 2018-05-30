using AppServices.EmployeeAuthentication;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.EmployeeAuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        // MOCKUP METHOD, TO BE IMPLEMENTED
        public int GetCurrentUserId()
        {
            return 1;
        }

        public void Initialize(IServiceCollection services)
        {


            throw new NotImplementedException();
        }

        // MOCKUP METHOD, TO BE IMPLEMENTED
        public bool IsUserAuthenticated()
        {
            return true;
        }
    }
}
