using AppServices.EmployeeAuthentication;
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

        // MOCKUP METHOD, TO BE IMPLEMENTED
        public bool IsUserAuthenticated()
        {
            return true;
        }
    }
}
