using Microsoft.Extensions.DependencyInjection;

namespace AppServices.EmployeeAuthentication

{
    public interface IAuthenticationService
    {
        int GetCurrentUserId();
        bool IsUserAuthenticated();
        void Initialize(IServiceCollection services);
    }
}
